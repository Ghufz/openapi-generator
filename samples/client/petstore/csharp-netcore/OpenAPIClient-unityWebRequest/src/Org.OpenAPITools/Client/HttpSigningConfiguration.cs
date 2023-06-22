/*
 * OpenAPI Petstore
 *
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Org.OpenAPITools.Client
{
    /// <summary>
    /// Class for HttpSigning auth related parameter and methods
    /// </summary>
    public class HttpSigningConfiguration
    {
        #region
        /// <summary>
        /// Initialize the HashAlgorithm and SigningAlgorithm to default value
        /// </summary>
        public HttpSigningConfiguration()
        {
            HashAlgorithm = HashAlgorithmName.SHA256;
            SigningAlgorithm = "PKCS1-v15";
        }
        #endregion

        #region Properties
        /// <summary>
        ///Gets the Api keyId
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// Gets the Key file path
        /// </summary>
        public string KeyFilePath { get; set; }

        /// <summary>
        /// Specify the API key in the form of a string, either configure the KeyString property or configure the KeyFilePath property.
        /// </summary>
        public string KeyString { get; set; }

        /// <summary>
        /// Gets the key pass phrase for password protected key
        /// </summary>
        public SecureString KeyPassPhrase { get; set; }

        /// <summary>
        /// Gets the HTTP signing header
        /// </summary>
        public List<string> HttpSigningHeader { get; set; }

        /// <summary>
        /// Gets the hash algorithm sha256 or sha512
        /// </summary>
        public HashAlgorithmName HashAlgorithm { get; set; }

        /// <summary>
        /// Gets the signing algorithm
        /// </summary>
        public string SigningAlgorithm { get; set; }

        /// <summary>
        /// Gets the Signature validity period in seconds
        /// </summary>
        public int SignatureValidityPeriod { get; set; }

        #endregion

        #region enum
        private enum PrivateKeyType
        {
            None = 0,
            RSA = 1,
            ECDSA = 2,
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the Headers for HttpSigning
        /// </summary>
        /// <param name="basePath">Base path</param>
        /// <param name="method">HTTP method</param>
        /// <param name="path">Path</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>Http signed headers</returns>
        internal Dictionary<string, string> GetHttpSignedHeader(string basePath,string method, string path, RequestOptions requestOptions)
        {
            const string HEADER_REQUEST_TARGET = "(request-target)";
            //The time when the HTTP signature expires. The API server should reject HTTP requests
            //that have expired.
            const string HEADER_EXPIRES = "(expires)";
            //The 'Date' header.
            const string HEADER_DATE = "Date";
            //The 'Host' header.
            const string HEADER_HOST = "Host";
            //The time when the HTTP signature was generated.
            const string HEADER_CREATED = "(created)";
            //When the 'Digest' header is included in the HTTP signature, the client automatically
            //computes the digest of the HTTP request body, per RFC 3230.
            const string HEADER_DIGEST = "Digest";
            //The 'Authorization' header is automatically generated by the client. It includes
            //the list of signed headers and a base64-encoded signature.
            const string HEADER_AUTHORIZATION = "Authorization";

            //Read the api key from the file
            if(string.IsNullOrEmpty(this.KeyString))
            {
                this.KeyString = ReadApiKeyFromFile(KeyFilePath);
            }

            if(string.IsNullOrEmpty(KeyString))
            {
                throw new Exception("No API key has been provided.");
            }

            //Hash table to store singed headers
            var HttpSignedRequestHeader = new Dictionary<string, string>();
            var HttpSignatureHeader = new Dictionary<string, string>();

            if (HttpSigningHeader.Count == 0)
            {
                HttpSigningHeader.Add("(created)");
            }

            if (requestOptions.PathParameters != null)
            {
                foreach (var pathParam in requestOptions.PathParameters)
                {
                    var tempPath = path.Replace(pathParam.Key, "0");
                    path = string.Format(tempPath, pathParam.Value);
                }
            }

            var httpValues = HttpUtility.ParseQueryString(string.Empty);
            foreach (var parameter in requestOptions.QueryParameters)
            {
#if (NETCOREAPP)
                if (parameter.Value.Count > 1)
                { // array
                    foreach (var value in parameter.Value)
                    {
                        httpValues.Add(HttpUtility.UrlEncode(parameter.Key) + "[]", value);
                    }
                }
                else
                {
                    httpValues.Add(HttpUtility.UrlEncode(parameter.Key), parameter.Value[0]);
                }
#else
                if (parameter.Value.Count > 1)
                { // array
                    foreach (var value in parameter.Value)
                    {
                        httpValues.Add(parameter.Key + "[]", value);
                    }
                }
                else
                {
                    httpValues.Add(parameter.Key, parameter.Value[0]);
                }
#endif
            }
            var uriBuilder = new UriBuilder(string.Concat(basePath, path));
            uriBuilder.Query = httpValues.ToString().Replace("+", "%20");

            var dateTime = DateTime.Now;
            string Digest = string.Empty;

            //get the body
            string requestBody = string.Empty;
            if (requestOptions.Data != null)
            {
                var serializerSettings = new JsonSerializerSettings();
                requestBody = JsonConvert.SerializeObject(requestOptions.Data, serializerSettings);
            }

            if (HashAlgorithm == HashAlgorithmName.SHA256)
            {
                var bodyDigest = GetStringHash(HashAlgorithm.ToString(), requestBody);
                Digest = string.Format("SHA-256={0}", Convert.ToBase64String(bodyDigest));
            }
            else if (HashAlgorithm == HashAlgorithmName.SHA512)
            {
                var bodyDigest = GetStringHash(HashAlgorithm.ToString(), requestBody);
                Digest = string.Format("SHA-512={0}", Convert.ToBase64String(bodyDigest));
            }
            else
            {
                throw new Exception(string.Format("{0} not supported", HashAlgorithm));
            }

            foreach (var header in HttpSigningHeader)
            {
                if (header.Equals(HEADER_REQUEST_TARGET))
                {
                    var targetUrl = string.Format("{0} {1}{2}", method.ToLower(), uriBuilder.Path, uriBuilder.Query);
                    HttpSignatureHeader.Add(header.ToLower(), targetUrl);
                }
                else if (header.Equals(HEADER_EXPIRES))
                {
                    var expireDateTime = dateTime.AddSeconds(SignatureValidityPeriod);
                    HttpSignatureHeader.Add(header.ToLower(), GetUnixTime(expireDateTime).ToString());
                }
                else if (header.Equals(HEADER_DATE))
                {
                    var utcDateTime = dateTime.ToUniversalTime().ToString("r");
                    HttpSignatureHeader.Add(header.ToLower(), utcDateTime);
                    HttpSignedRequestHeader.Add(HEADER_DATE, utcDateTime);
                }
                else if (header.Equals(HEADER_HOST))
                {
                    HttpSignatureHeader.Add(header.ToLower(), uriBuilder.Host);
                    HttpSignedRequestHeader.Add(HEADER_HOST, uriBuilder.Host);
                }
                else if (header.Equals(HEADER_CREATED))
                {
                    HttpSignatureHeader.Add(header.ToLower(), GetUnixTime(dateTime).ToString());
                }
                else if (header.Equals(HEADER_DIGEST))
                {
                    HttpSignedRequestHeader.Add(HEADER_DIGEST, Digest);
                    HttpSignatureHeader.Add(header.ToLower(), Digest);
                }
                else
                {
                    bool isHeaderFound = false;
                    foreach (var item in requestOptions.HeaderParameters)
                    {
                        if (string.Equals(item.Key, header, StringComparison.OrdinalIgnoreCase))
                        {
                            HttpSignatureHeader.Add(header.ToLower(), item.Value.ToString());
                            isHeaderFound = true;
                            break;
                        }
                    }
                    if (!isHeaderFound)
                    {
                        throw new Exception(string.Format("Cannot sign HTTP request.Request does not contain the {0} header.",header));
                    }
                }

            }
            var headersKeysString = string.Join(" ", HttpSignatureHeader.Keys);
            var headerValuesList = new List<string>();

            foreach (var keyVal in HttpSignatureHeader)
            {
                headerValuesList.Add(string.Format("{0}: {1}", keyVal.Key, keyVal.Value));
            }
            //Concatenate headers value separated by new line
            var headerValuesString = string.Join("\n", headerValuesList);
            var signatureStringHash = GetStringHash(HashAlgorithm.ToString(), headerValuesString);
            string headerSignatureStr = null;
            var keyType = GetKeyType(KeyString);

            if (keyType == PrivateKeyType.RSA)
            {
                headerSignatureStr = GetRSASignature(signatureStringHash);
            }
            else if (keyType == PrivateKeyType.ECDSA)
            {
                headerSignatureStr = GetECDSASignature(signatureStringHash);
            }
            else
            {
                throw new Exception(string.Format("Private key type {0} not supported", keyType));
            }
            const string cryptographicScheme = "hs2019";
            var authorizationHeaderValue = string.Format("Signature keyId=\"{0}\",algorithm=\"{1}\"",
                KeyId, cryptographicScheme);

            if (HttpSignatureHeader.ContainsKey(HEADER_CREATED))
            {
                authorizationHeaderValue += string.Format(",created={0}", HttpSignatureHeader[HEADER_CREATED]);
            }

            if (HttpSignatureHeader.ContainsKey(HEADER_EXPIRES))
            {
                authorizationHeaderValue += string.Format(",expires={0}", HttpSignatureHeader[HEADER_EXPIRES]);
            }

            authorizationHeaderValue += string.Format(",headers=\"{0}\",signature=\"{1}\"",
                headersKeysString, headerSignatureStr);
            HttpSignedRequestHeader.Add(HEADER_AUTHORIZATION, authorizationHeaderValue);
            return HttpSignedRequestHeader;
        }

        private byte[] GetStringHash(string hashName, string stringToBeHashed)
        {
            var hashAlgorithm = System.Security.Cryptography.HashAlgorithm.Create(hashName);
            var bytes = Encoding.UTF8.GetBytes(stringToBeHashed);
            var stringHash = hashAlgorithm.ComputeHash(bytes);
            return stringHash;
        }

        private int GetUnixTime(DateTime date2)
        {
            DateTime date1 = new DateTime(1970, 01, 01);
            TimeSpan timeSpan = date2 - date1;
            return (int)timeSpan.TotalSeconds;
        }

        private string GetRSASignature(byte[] stringToSign)
        {
            RSA rsa = GetRSAProviderFromPemFile(KeyString, KeyPassPhrase);
            if (SigningAlgorithm == "RSASSA-PSS")
            {
                var signedbytes = rsa.SignHash(stringToSign, HashAlgorithm, RSASignaturePadding.Pss);
                return Convert.ToBase64String(signedbytes);
            }
            else if (SigningAlgorithm == "PKCS1-v15")
            {
                var signedbytes = rsa.SignHash(stringToSign, HashAlgorithm, RSASignaturePadding.Pkcs1);
                return Convert.ToBase64String(signedbytes);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the ECDSA signature
        /// </summary>
        /// <param name="dataToSign"></param>
        /// <returns>ECDSA signature</returns>
        private string GetECDSASignature(byte[] dataToSign)
        {
            var keyStr = KeyString;
            const string ecKeyHeader = "-----BEGIN EC PRIVATE KEY-----";
            const string ecKeyFooter = "-----END EC PRIVATE KEY-----";
            var ecKeyBase64String = keyStr.Replace(ecKeyHeader, "").Replace(ecKeyFooter, "").Trim();
            var keyBytes = System.Convert.FromBase64String(ecKeyBase64String);
            var ecdsa = ECDsa.Create();

#if (NETCOREAPP3_0 || NETCOREAPP3_1 || NET5_0)
            var byteCount = 0;
            if (KeyPassPhrase != null)
            {
                IntPtr unmanagedString = IntPtr.Zero;
                try
                {
                    // convert secure string to byte array
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(KeyPassPhrase);
                    ecdsa.ImportEncryptedPkcs8PrivateKey(Encoding.UTF8.GetBytes(Marshal.PtrToStringUni(unmanagedString)), keyBytes, out byteCount);
                }
                finally
                {
                    if (unmanagedString != IntPtr.Zero)
                    {
                        Marshal.ZeroFreeBSTR(unmanagedString);
                    }
                }
            }
            else
            {
                ecdsa.ImportPkcs8PrivateKey(keyBytes, out byteCount);
            }
            var signedBytes = ecdsa.SignHash(dataToSign);
            var derBytes = ConvertToECDSAANS1Format(signedBytes);
            var signedString = System.Convert.ToBase64String(derBytes);

            return signedString;
#else
            throw new Exception("ECDSA signing is supported only on NETCOREAPP3_0 and above");
#endif
        }

        private byte[] ConvertToECDSAANS1Format(byte[] signedBytes)
        {
            var derBytes = new List<byte>();
            byte derLength = 68; //default length for ECDSA code signing bit 0x44
            byte rbytesLength = 32; //R length 0x20
            byte sbytesLength = 32; //S length 0x20
            var rBytes = new List<byte>();
            var sBytes = new List<byte>();
            for (int i = 0; i < 32; i++)
            {
                rBytes.Add(signedBytes[i]);
            }
            for (int i = 32; i < 64; i++)
            {
                sBytes.Add(signedBytes[i]);
            }

            if (rBytes[0] > 0x7F)
            {
                derLength++;
                rbytesLength++;
                var tempBytes = new List<byte>();
                tempBytes.AddRange(rBytes);
                rBytes.Clear();
                rBytes.Add(0x00);
                rBytes.AddRange(tempBytes);
            }

            if (sBytes[0] > 0x7F)
            {
                derLength++;
                sbytesLength++;
                var tempBytes = new List<byte>();
                tempBytes.AddRange(sBytes);
                sBytes.Clear();
                sBytes.Add(0x00);
                sBytes.AddRange(tempBytes);

            }

            derBytes.Add(48);  //start of the sequence 0x30
            derBytes.Add(derLength);  //total length r length, type and r bytes

            derBytes.Add(2); //tag for integer
            derBytes.Add(rbytesLength); //length of r
            derBytes.AddRange(rBytes);

            derBytes.Add(2); //tag for integer
            derBytes.Add(sbytesLength); //length of s
            derBytes.AddRange(sBytes);
            return derBytes.ToArray();
        }

        private  RSACryptoServiceProvider GetRSAProviderFromPemFile(string keyString, SecureString keyPassPhrase = null)
        {
            const string pempubheader = "-----BEGIN PUBLIC KEY-----";
            const string pempubfooter = "-----END PUBLIC KEY-----";
            bool isPrivateKeyFile = true;
            byte[] pemkey = null;
            string pemstr = keyString;

            if (pemstr.StartsWith(pempubheader) && pemstr.EndsWith(pempubfooter))
            {
                isPrivateKeyFile = false;
            }

            if (isPrivateKeyFile)
            {
                pemkey = ConvertPrivateKeyToBytes(pemstr, keyPassPhrase);
                if (pemkey == null)
                {
                    return null;
                }
                return DecodeRSAPrivateKey(pemkey);
            }
            return null;
        }

        private byte[] ConvertPrivateKeyToBytes(string instr, SecureString keyPassPhrase = null)
        {
            const string pemprivheader = "-----BEGIN RSA PRIVATE KEY-----";
            const string pemprivfooter = "-----END RSA PRIVATE KEY-----";
            string pemstr = instr.Trim();
            byte[] binkey;

            if (!pemstr.StartsWith(pemprivheader) || !pemstr.EndsWith(pemprivfooter))
            {
                return null;
            }

            StringBuilder sb = new StringBuilder(pemstr);
            sb.Replace(pemprivheader, "");
            sb.Replace(pemprivfooter, "");
            string pvkstr = sb.ToString().Trim();

            try
            {   // if there are no PEM encryption info lines, this is an UNencrypted PEM private key
                binkey = Convert.FromBase64String(pvkstr);
                return binkey;
            }
            catch (System.FormatException)
            {
                StringReader str = new StringReader(pvkstr);

                //-------- read PEM encryption info. lines and extract salt -----
                if (!str.ReadLine().StartsWith("Proc-Type: 4,ENCRYPTED"))
                {
                    return null;
                }
                string saltline = str.ReadLine();
                if (!saltline.StartsWith("DEK-Info: DES-EDE3-CBC,"))
                {
                    return null;
                }
                string saltstr = saltline.Substring(saltline.IndexOf(",") + 1).Trim();
                byte[] salt = new byte[saltstr.Length / 2];
                for (int i = 0; i < salt.Length; i++)
                    salt[i] = Convert.ToByte(saltstr.Substring(i * 2, 2), 16);
                if (str.ReadLine() != "")
                {
                    return null;
                }

                //------ remaining b64 data is encrypted RSA key ----
                string encryptedstr = str.ReadToEnd();

                try
                {   //should have b64 encrypted RSA key now
                    binkey = Convert.FromBase64String(encryptedstr);
                }
                catch (System.FormatException)
                {   //data is not in base64 format
                    return null;
                }

                byte[] deskey = GetEncryptedKey(salt, keyPassPhrase, 1, 2);    // count=1 (for OpenSSL implementation); 2 iterations to get at least 24 bytes
                if (deskey == null)
                {
                    return null;
                }

                //------ Decrypt the encrypted 3des-encrypted RSA private key ------
                byte[] rsakey = DecryptKey(binkey, deskey, salt); //OpenSSL uses salt value in PEM header also as 3DES IV
                return rsakey;
            }
        }

        private RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
        {
            byte[] bytesModulus, bytesE, bytesD, bytesP, bytesQ, bytesDP, bytesDQ, bytesIQ;

            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                {
                    binr.ReadByte();    //advance 1 byte
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16();   //advance 2 bytes
                }
                else
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) //version number
                {
                    return null;
                }
                bt = binr.ReadByte();
                if (bt != 0x00)
                {
                    return null;
                }

                //------  all private key components are Integer sequences ----
                elems = GetIntegerSize(binr);
                bytesModulus = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                bytesE = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                bytesD = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                bytesP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                bytesQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                bytesDP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                bytesDQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                bytesIQ = binr.ReadBytes(elems);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAparams = new RSAParameters();
                RSAparams.Modulus = bytesModulus;
                RSAparams.Exponent = bytesE;
                RSAparams.D = bytesD;
                RSAparams.P = bytesP;
                RSAparams.Q = bytesQ;
                RSAparams.DP = bytesDP;
                RSAparams.DQ = bytesDQ;
                RSAparams.InverseQ = bytesIQ;
                RSA.ImportParameters(RSAparams);
                return RSA;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        private int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02) //expect integer
            {
                return 0;
            }
            bt = binr.ReadByte();

            if (bt == 0x81)
            {
                count = binr.ReadByte();    // data size in next byte
            }
            else if (bt == 0x82)
            {
                highbyte = binr.ReadByte(); // data size in next 2 bytes
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;     // we already have the data size
            }
            while (binr.ReadByte() == 0x00)
            {
                //remove high order zeros in data
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            //last ReadByte wasn't a removed zero, so back up a byte
            return count;
        }

        private byte[] GetEncryptedKey(byte[] salt, SecureString secpswd, int count, int miter)
        {
            IntPtr unmanagedPswd = IntPtr.Zero;
            const int HASHLENGTH = 16;    //MD5 bytes
            byte[] keymaterial = new byte[HASHLENGTH * miter];     //to store concatenated Mi hashed results

            byte[] psbytes = new byte[secpswd.Length];
            unmanagedPswd = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
            Marshal.Copy(unmanagedPswd, psbytes, 0, psbytes.Length);
            Marshal.ZeroFreeGlobalAllocAnsi(unmanagedPswd);

            // --- concatenate salt and pswd bytes into fixed data array ---
            byte[] data00 = new byte[psbytes.Length + salt.Length];
            Array.Copy(psbytes, data00, psbytes.Length);      //copy the pswd bytes
            Array.Copy(salt, 0, data00, psbytes.Length, salt.Length); //concatenate the salt bytes

            // ---- do multi-hashing and concatenate results  D1, D2 ...  into keymaterial bytes ----
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = null;
            byte[] hashtarget = new byte[HASHLENGTH + data00.Length];   //fixed length initial hashtarget

            for (int j = 0; j < miter; j++)
            {
                // ----  Now hash consecutively for count times ------
                if (j == 0)
                {
                    result = data00;    //initialize
                }
                else
                {
                    Array.Copy(result, hashtarget, result.Length);
                    Array.Copy(data00, 0, hashtarget, result.Length, data00.Length);
                    result = hashtarget;
                }

                for (int i = 0; i < count; i++)
                {
                    result = md5.ComputeHash(result);
                }
                Array.Copy(result, 0, keymaterial, j * HASHLENGTH, result.Length);  //concatenate to keymaterial
            }
            byte[] deskey = new byte[24];
            Array.Copy(keymaterial, deskey, deskey.Length);

            Array.Clear(psbytes, 0, psbytes.Length);
            Array.Clear(data00, 0, data00.Length);
            Array.Clear(result, 0, result.Length);
            Array.Clear(hashtarget, 0, hashtarget.Length);
            Array.Clear(keymaterial, 0, keymaterial.Length);
            return deskey;
        }

        private byte[] DecryptKey(byte[] cipherData, byte[] desKey, byte[] IV)
        {
            MemoryStream memst = new MemoryStream();
            TripleDES alg = TripleDES.Create();
            alg.Key = desKey;
            alg.IV = IV;
            try
            {
                CryptoStream cs = new CryptoStream(memst, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();
            }
            catch (Exception)
            {
                return null;
            }
            byte[] decryptedData = memst.ToArray();
            return decryptedData;
        }

        /// <summary>
        /// Detect the key type from the pem file.
        /// </summary>
        /// <param name="keyString">api key in string format</param>
        /// <returns>Private Key Type</returns>
        private PrivateKeyType GetKeyType(string keyString)
        {
            string[] key = null;

            if (string.IsNullOrEmpty(keyString))
            {
                throw new Exception("No API key has been provided.");
            }

            const string ecPrivateKeyHeader = "BEGIN EC PRIVATE KEY";
            const string ecPrivateKeyFooter = "END EC PRIVATE KEY";
            const string rsaPrivateKeyHeader = "BEGIN RSA PRIVATE KEY";
            const string rsaPrivateFooter = "END RSA PRIVATE KEY";
            //var pkcs8Header = "BEGIN PRIVATE KEY";
            //var pkcs8Footer = "END PRIVATE KEY";
            PrivateKeyType keyType;
            key = KeyString.TrimEnd().Split('\n');

            if (key[0].Contains(rsaPrivateKeyHeader) &&
                key[key.Length - 1].ToString().Contains(rsaPrivateFooter))
            {
                keyType = PrivateKeyType.RSA;
            }
            else if (key[0].Contains(ecPrivateKeyHeader) &&
                key[key.Length - 1].ToString().Contains(ecPrivateKeyFooter))
            {
                keyType = PrivateKeyType.ECDSA;
            }
            else
            {
                throw new Exception("The key file path does not exist or key is invalid or key is not supported");
            }
            return keyType;
        }

        /// <summary>
        /// Read the api key form the api key file path and stored it in KeyString property.
        /// </summary>
        /// <param name="apiKeyFilePath">api key file path</param>
        private string ReadApiKeyFromFile(string apiKeyFilePath)
        {
            string apiKeyString = null;
            
            if(File.Exists(apiKeyFilePath))
            {
                apiKeyString = File.ReadAllText(apiKeyFilePath);
            }
            else
            {
                throw new Exception("Provided API key file path does not exists.");
            }
            return apiKeyString;
        }
        #endregion
    }
}
