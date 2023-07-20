/*
 * OpenAPI Petstore
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


package org.openapitools.client.model;

import java.util.Objects;
import java.util.Arrays;
import com.google.gson.TypeAdapter;
import com.google.gson.annotations.JsonAdapter;
import com.google.gson.annotations.SerializedName;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.IOException;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import android.os.Parcelable;
import android.os.Parcel;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonArray;
import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParseException;
import com.google.gson.TypeAdapterFactory;
import com.google.gson.reflect.TypeToken;
import com.google.gson.TypeAdapter;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.IOException;

import java.lang.reflect.Type;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import org.openapitools.client.JSON;

/**
 * ArrayOfArrayOfNumberOnly
 */
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen")
public class ArrayOfArrayOfNumberOnly implements Parcelable {
  public static final String SERIALIZED_NAME_ARRAY_ARRAY_NUMBER = "ArrayArrayNumber";
  @SerializedName(SERIALIZED_NAME_ARRAY_ARRAY_NUMBER)
  private List<List<BigDecimal>> arrayArrayNumber;

  public ArrayOfArrayOfNumberOnly() {
  }

  public ArrayOfArrayOfNumberOnly arrayArrayNumber(List<List<BigDecimal>> arrayArrayNumber) {
    
    this.arrayArrayNumber = arrayArrayNumber;
    return this;
  }

  public ArrayOfArrayOfNumberOnly addArrayArrayNumberItem(List<BigDecimal> arrayArrayNumberItem) {
    if (this.arrayArrayNumber == null) {
      this.arrayArrayNumber = new ArrayList<>();
    }
    this.arrayArrayNumber.add(arrayArrayNumberItem);
    return this;
  }

   /**
   * Get arrayArrayNumber
   * @return arrayArrayNumber
  **/
  @javax.annotation.Nullable
  public List<List<BigDecimal>> getArrayArrayNumber() {
    return arrayArrayNumber;
  }


  public void setArrayArrayNumber(List<List<BigDecimal>> arrayArrayNumber) {
    this.arrayArrayNumber = arrayArrayNumber;
  }



  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    ArrayOfArrayOfNumberOnly arrayOfArrayOfNumberOnly = (ArrayOfArrayOfNumberOnly) o;
    return Objects.equals(this.arrayArrayNumber, arrayOfArrayOfNumberOnly.arrayArrayNumber);
  }

  @Override
  public int hashCode() {
    return Objects.hash(arrayArrayNumber);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class ArrayOfArrayOfNumberOnly {\n");
    sb.append("    arrayArrayNumber: ").append(toIndentedString(arrayArrayNumber)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }


  public void writeToParcel(Parcel out, int flags) {
    out.writeValue(arrayArrayNumber);
  }

  ArrayOfArrayOfNumberOnly(Parcel in) {
    arrayArrayNumber = (List<List<BigDecimal>>)in.readValue(List.class.getClassLoader());
  }

  public int describeContents() {
    return 0;
  }

  public static final Parcelable.Creator<ArrayOfArrayOfNumberOnly> CREATOR = new Parcelable.Creator<ArrayOfArrayOfNumberOnly>() {
    public ArrayOfArrayOfNumberOnly createFromParcel(Parcel in) {
      return new ArrayOfArrayOfNumberOnly(in);
    }
    public ArrayOfArrayOfNumberOnly[] newArray(int size) {
      return new ArrayOfArrayOfNumberOnly[size];
    }
  };

  public static HashSet<String> openapiFields;
  public static HashSet<String> openapiRequiredFields;

  static {
    // a set of all properties/fields (JSON key names)
    openapiFields = new HashSet<String>();
    openapiFields.add("ArrayArrayNumber");

    // a set of required properties/fields (JSON key names)
    openapiRequiredFields = new HashSet<String>();
  }

 /**
  * Validates the JSON Element and throws an exception if issues found
  *
  * @param jsonElement JSON Element
  * @throws IOException if the JSON Element is invalid with respect to ArrayOfArrayOfNumberOnly
  */
  public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      if (jsonElement == null) {
        if (!ArrayOfArrayOfNumberOnly.openapiRequiredFields.isEmpty()) { // has required fields but JSON element is null
          throw new IllegalArgumentException(String.format("The required field(s) %s in ArrayOfArrayOfNumberOnly is not found in the empty JSON string", ArrayOfArrayOfNumberOnly.openapiRequiredFields.toString()));
        }
      }

      Set<Entry<String, JsonElement>> entries = jsonElement.getAsJsonObject().entrySet();
      // check to see if the JSON string contains additional fields
      for (Entry<String, JsonElement> entry : entries) {
        if (!ArrayOfArrayOfNumberOnly.openapiFields.contains(entry.getKey())) {
          throw new IllegalArgumentException(String.format("The field `%s` in the JSON string is not defined in the `ArrayOfArrayOfNumberOnly` properties. JSON: %s", entry.getKey(), jsonElement.toString()));
        }
      }
        JsonObject jsonObj = jsonElement.getAsJsonObject();
      // ensure the optional json data is an array if present
      if (jsonObj.get("ArrayArrayNumber") != null && !jsonObj.get("ArrayArrayNumber").isJsonArray()) {
        throw new IllegalArgumentException(String.format("Expected the field `ArrayArrayNumber` to be an array in the JSON string but got `%s`", jsonObj.get("ArrayArrayNumber").toString()));
      }
  }

  public static class CustomTypeAdapterFactory implements TypeAdapterFactory {
    @SuppressWarnings("unchecked")
    @Override
    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
       if (!ArrayOfArrayOfNumberOnly.class.isAssignableFrom(type.getRawType())) {
         return null; // this class only serializes 'ArrayOfArrayOfNumberOnly' and its subtypes
       }
       final TypeAdapter<JsonElement> elementAdapter = gson.getAdapter(JsonElement.class);
       final TypeAdapter<ArrayOfArrayOfNumberOnly> thisAdapter
                        = gson.getDelegateAdapter(this, TypeToken.get(ArrayOfArrayOfNumberOnly.class));

       return (TypeAdapter<T>) new TypeAdapter<ArrayOfArrayOfNumberOnly>() {
           @Override
           public void write(JsonWriter out, ArrayOfArrayOfNumberOnly value) throws IOException {
             JsonObject obj = thisAdapter.toJsonTree(value).getAsJsonObject();
             elementAdapter.write(out, obj);
           }

           @Override
           public ArrayOfArrayOfNumberOnly read(JsonReader in) throws IOException {
             JsonElement jsonElement = elementAdapter.read(in);
             validateJsonElement(jsonElement);
             return thisAdapter.fromJsonTree(jsonElement);
           }

       }.nullSafe();
    }
  }

 /**
  * Create an instance of ArrayOfArrayOfNumberOnly given an JSON string
  *
  * @param jsonString JSON string
  * @return An instance of ArrayOfArrayOfNumberOnly
  * @throws IOException if the JSON string is invalid with respect to ArrayOfArrayOfNumberOnly
  */
  public static ArrayOfArrayOfNumberOnly fromJson(String jsonString) throws IOException {
    return JSON.getGson().fromJson(jsonString, ArrayOfArrayOfNumberOnly.class);
  }

 /**
  * Convert an instance of ArrayOfArrayOfNumberOnly to an JSON string
  *
  * @return JSON string
  */
  public String toJson() {
    return JSON.getGson().toJson(this);
  }
}

