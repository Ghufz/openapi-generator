--  OpenAPI Petstore
--  This is a sample server Petstore server. For this sample, you can use the api key `special_key` to test the authorization filters.
--
--  The version of the OpenAPI document: 1.0.0
--
--
--  NOTE: This package is auto generated by OpenAPI-Generator 7.3.0-SNAPSHOT.
--  https://openapi-generator.tech
--  Do not edit the class manually.

with Samples.Petstore.Models;
with Swagger.Clients;
package Samples.Petstore.Clients is
   pragma Style_Checks ("-bmrIu");

   type Client_Type is new Swagger.Clients.Client_Type with null record;

   --  parameter name mapping test
   procedure Get_Parameter_Name_Mapping
      (Client : in out Client_Type;
       UnderscoreType : in Swagger.Long;
       P_Type : in Swagger.UString;
       TypeWithUnderscore : in Swagger.UString;
       Http_Debug_Option : in Swagger.UString);

   --  Add a new pet to the store
   procedure Add_Pet
      (Client : in out Client_Type;
       Pet_Type : in Samples.Petstore.Models.Pet_Type;
       Result : out Samples.Petstore.Models.Pet_Type);

   --  Deletes a pet
   procedure Delete_Pet
      (Client : in out Client_Type;
       Pet_Id : in Swagger.Long;
       Api_Key : in Swagger.Nullable_UString);

   --  Finds Pets by status
   --  Multiple status values can be provided with comma separated strings
   procedure Find_Pets_By_Status
      (Client : in out Client_Type;
       Status : in Swagger.UString_Vectors.Vector;
       Result : out Samples.Petstore.Models.Pet_Type_Vectors.Vector);

   --  Finds Pets by tags
   --  Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.
   procedure Find_Pets_By_Tags
      (Client : in out Client_Type;
       Tags : in Swagger.UString_Vectors.Vector;
       Result : out Samples.Petstore.Models.Pet_Type_Vectors.Vector);

   --  Find pet by ID
   --  Returns a single pet
   procedure Get_Pet_By_Id
      (Client : in out Client_Type;
       Pet_Id : in Swagger.Long;
       Result : out Samples.Petstore.Models.Pet_Type);

   --  Update an existing pet
   procedure Update_Pet
      (Client : in out Client_Type;
       Pet_Type : in Samples.Petstore.Models.Pet_Type;
       Result : out Samples.Petstore.Models.Pet_Type);

   --  Updates a pet in the store with form data
   procedure Update_Pet_With_Form
      (Client : in out Client_Type;
       Pet_Id : in Swagger.Long;
       Name : in Swagger.Nullable_UString;
       Status : in Swagger.Nullable_UString);

   --  uploads an image
   procedure Upload_File
      (Client : in out Client_Type;
       Pet_Id : in Swagger.Long;
       Additional_Metadata : in Swagger.Nullable_UString;
       File : in Swagger.File_Part_Type;
       Result : out Samples.Petstore.Models.ApiResponse_Type);

   --  Delete purchase order by ID
   --  For valid response try integer IDs with value < 1000. Anything above 1000 or nonintegers will generate API errors
   procedure Delete_Order
      (Client : in out Client_Type;
       Order_Id : in Swagger.UString);

   --  Returns pet inventories by status
   --  Returns a map of status codes to quantities
   procedure Get_Inventory
      (Client : in out Client_Type;
       Result : out Swagger.Integer_Map);

   --  Find purchase order by ID
   --  For valid response try integer IDs with value <= 5 or > 10. Other values will generate exceptions
   procedure Get_Order_By_Id
      (Client : in out Client_Type;
       Order_Id : in Swagger.Long;
       Result : out Samples.Petstore.Models.Order_Type);

   --  Place an order for a pet
   procedure Place_Order
      (Client : in out Client_Type;
       Order_Type : in Samples.Petstore.Models.Order_Type;
       Result : out Samples.Petstore.Models.Order_Type);

   --  Create user
   --  This can only be done by the logged in user.
   procedure Create_User
      (Client : in out Client_Type;
       User_Type : in Samples.Petstore.Models.User_Type);

   --  Creates list of users with given input array
   procedure Create_Users_With_Array_Input
      (Client : in out Client_Type;
       User : in Samples.Petstore.Models.User_Type_Vectors.Vector);

   --  Creates list of users with given input array
   procedure Create_Users_With_List_Input
      (Client : in out Client_Type;
       User : in Samples.Petstore.Models.User_Type_Vectors.Vector);

   --  Delete user
   --  This can only be done by the logged in user.
   procedure Delete_User
      (Client : in out Client_Type;
       Username : in Swagger.UString);

   --  Get user by user name
   procedure Get_User_By_Name
      (Client : in out Client_Type;
       Username : in Swagger.UString;
       Result : out Samples.Petstore.Models.User_Type);

   --  Logs user into the system
   procedure Login_User
      (Client : in out Client_Type;
       Username : in Swagger.UString;
       Password : in Swagger.UString;
       Result : out Swagger.UString);

   --  Logs out current logged in user session
   procedure Logout_User
      (Client : in out Client_Type);

   --  Updated user
   --  This can only be done by the logged in user.
   procedure Update_User
      (Client : in out Client_Type;
       Username : in Swagger.UString;
       User_Type : in Samples.Petstore.Models.User_Type);

end Samples.Petstore.Clients;
