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

package org.openapitools.model;

import java.util.Objects;
import java.util.Arrays;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import com.fasterxml.jackson.annotation.*;

import javax.validation.constraints.*;
import javax.validation.Valid;
import io.micronaut.core.annotation.*;
import javax.annotation.Generated;

/**
 * TypeHolderDefault
 */
@JsonPropertyOrder({
  TypeHolderDefault.JSON_PROPERTY_STRING_ITEM,
  TypeHolderDefault.JSON_PROPERTY_NUMBER_ITEM,
  TypeHolderDefault.JSON_PROPERTY_INTEGER_ITEM,
  TypeHolderDefault.JSON_PROPERTY_BOOL_ITEM,
  TypeHolderDefault.JSON_PROPERTY_ARRAY_ITEM
})
@JsonTypeName("TypeHolderDefault")
@Generated(value="org.openapitools.codegen.languages.JavaMicronautClientCodegen", comments = "Generator version: 7.6.0-SNAPSHOT")
@Introspected
public class TypeHolderDefault {
    public static final String JSON_PROPERTY_STRING_ITEM = "string_item";
    private String stringItem = "what";

    public static final String JSON_PROPERTY_NUMBER_ITEM = "number_item";
    private BigDecimal numberItem;

    public static final String JSON_PROPERTY_INTEGER_ITEM = "integer_item";
    private Integer integerItem;

    public static final String JSON_PROPERTY_BOOL_ITEM = "bool_item";
    private Boolean boolItem = true;

    public static final String JSON_PROPERTY_ARRAY_ITEM = "array_item";
    private List<Integer> arrayItem = new ArrayList<>();

    public TypeHolderDefault() {
    }
    public TypeHolderDefault stringItem(String stringItem) {
        this.stringItem = stringItem;
        return this;
    }

    /**
     * Get stringItem
     * @return stringItem
     **/
    @NotNull
    @JsonProperty(JSON_PROPERTY_STRING_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public String getStringItem() {
        return stringItem;
    }

    @JsonProperty(JSON_PROPERTY_STRING_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public void setStringItem(String stringItem) {
        this.stringItem = stringItem;
    }

    public TypeHolderDefault numberItem(BigDecimal numberItem) {
        this.numberItem = numberItem;
        return this;
    }

    /**
     * Get numberItem
     * @return numberItem
     **/
    @NotNull
    @JsonProperty(JSON_PROPERTY_NUMBER_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public BigDecimal getNumberItem() {
        return numberItem;
    }

    @JsonProperty(JSON_PROPERTY_NUMBER_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public void setNumberItem(BigDecimal numberItem) {
        this.numberItem = numberItem;
    }

    public TypeHolderDefault integerItem(Integer integerItem) {
        this.integerItem = integerItem;
        return this;
    }

    /**
     * Get integerItem
     * @return integerItem
     **/
    @NotNull
    @JsonProperty(JSON_PROPERTY_INTEGER_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public Integer getIntegerItem() {
        return integerItem;
    }

    @JsonProperty(JSON_PROPERTY_INTEGER_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public void setIntegerItem(Integer integerItem) {
        this.integerItem = integerItem;
    }

    public TypeHolderDefault boolItem(Boolean boolItem) {
        this.boolItem = boolItem;
        return this;
    }

    /**
     * Get boolItem
     * @return boolItem
     **/
    @NotNull
    @JsonProperty(JSON_PROPERTY_BOOL_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public Boolean getBoolItem() {
        return boolItem;
    }

    @JsonProperty(JSON_PROPERTY_BOOL_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public void setBoolItem(Boolean boolItem) {
        this.boolItem = boolItem;
    }

    public TypeHolderDefault arrayItem(List<Integer> arrayItem) {
        this.arrayItem = arrayItem;
        return this;
    }

    public TypeHolderDefault addArrayItemItem(Integer arrayItemItem) {
        this.arrayItem.add(arrayItemItem);
        return this;
    }

    /**
     * Get arrayItem
     * @return arrayItem
     **/
    @NotNull
    @JsonProperty(JSON_PROPERTY_ARRAY_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public List<Integer> getArrayItem() {
        return arrayItem;
    }

    @JsonProperty(JSON_PROPERTY_ARRAY_ITEM)
    @JsonInclude(value = JsonInclude.Include.ALWAYS)
    public void setArrayItem(List<Integer> arrayItem) {
        this.arrayItem = arrayItem;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        TypeHolderDefault typeHolderDefault = (TypeHolderDefault) o;
        return Objects.equals(this.stringItem, typeHolderDefault.stringItem) &&
            Objects.equals(this.numberItem, typeHolderDefault.numberItem) &&
            Objects.equals(this.integerItem, typeHolderDefault.integerItem) &&
            Objects.equals(this.boolItem, typeHolderDefault.boolItem) &&
            Objects.equals(this.arrayItem, typeHolderDefault.arrayItem);
    }

    @Override
    public int hashCode() {
        return Objects.hash(stringItem, numberItem, integerItem, boolItem, arrayItem);
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("class TypeHolderDefault {\n");
        sb.append("    stringItem: ").append(toIndentedString(stringItem)).append("\n");
        sb.append("    numberItem: ").append(toIndentedString(numberItem)).append("\n");
        sb.append("    integerItem: ").append(toIndentedString(integerItem)).append("\n");
        sb.append("    boolItem: ").append(toIndentedString(boolItem)).append("\n");
        sb.append("    arrayItem: ").append(toIndentedString(arrayItem)).append("\n");
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

}

