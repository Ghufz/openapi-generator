/*
 * OpenAPI Petstore
 *
 * This is a sample server Petstore server. For this sample, you can use the api key `special-key` to test the authorization filters.
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

/// ApiResponse : Describes the result of uploading an image resource



#[derive(Clone, Debug, PartialEq, Default, Serialize, Deserialize)]
pub struct ApiResponse {
    #[serde(rename = "code", skip_serializing_if = "Option::is_none")]
    pub code: Option<i32>,
    #[serde(rename = "type", skip_serializing_if = "Option::is_none")]
    pub r#type: Option<String>,
    #[serde(rename = "message", skip_serializing_if = "Option::is_none")]
    pub message: Option<String>,
}

impl ApiResponse {
    /// Describes the result of uploading an image resource
    pub fn new() -> ApiResponse {
        ApiResponse {
            code: None,
            r#type: None,
            message: None,
        }
    }
}


