# coding: utf-8

"""
    Echo Server API

    Echo Server API

    The version of the OpenAPI document: 0.1.0
    Contact: team@openapitools.org
    Generated by OpenAPI Generator (https://openapi-generator.tech)

    Do not edit the class manually.
"""  # noqa: E501


import io
import warnings

from pydantic import validate_call, Field, StrictFloat, StrictStr, StrictInt
from typing import Dict, List, Optional, Tuple, Union, Any

try:
    from typing import Annotated
except ImportError:
    from typing_extensions import Annotated

from pydantic import StrictBool, StrictInt, StrictStr, field_validator

from typing import Optional

from openapi_client.models.string_enum_ref import StringEnumRef

from openapi_client.api_client import ApiClient
from openapi_client.api_response import ApiResponse
from openapi_client.rest import RESTResponseType


class HeaderApi:
    """NOTE: This class is auto generated by OpenAPI Generator
    Ref: https://openapi-generator.tech

    Do not edit the class manually.
    """

    def __init__(self, api_client=None) -> None:
        if api_client is None:
            api_client = ApiClient.get_default()
        self.api_client = api_client


    @validate_call
    def test_header_integer_boolean_string_enums(
        self,
        integer_header: Optional[StrictInt] = None,
        boolean_header: Optional[StrictBool] = None,
        string_header: Optional[StrictStr] = None,
        enum_nonref_string_header: Optional[StrictStr] = None,
        enum_ref_string_header: Optional[StringEnumRef] = None,
        _request_timeout: Union[
            None,
            Annotated[StrictFloat, Field(gt=0)],
            Tuple[
                Annotated[StrictFloat, Field(gt=0)],
                Annotated[StrictFloat, Field(gt=0)]
            ]
        ] = None,
        _request_auth: Optional[Dict[StrictStr, Any]] = None,
        _content_type: Optional[StrictStr] = None,
        _headers: Optional[Dict[StrictStr, Any]] = None,
        _host_index: Annotated[StrictInt, Field(ge=0, le=0)] = 0,
    ) -> str:
        """Test header parameter(s)

        Test header parameter(s)

        :param integer_header:
        :type integer_header: int
        :param boolean_header:
        :type boolean_header: bool
        :param string_header:
        :type string_header: str
        :param enum_nonref_string_header:
        :type enum_nonref_string_header: str
        :param enum_ref_string_header:
        :type enum_ref_string_header: StringEnumRef
        :param _request_timeout: timeout setting for this request. If one
                                 number provided, it will be total request
                                 timeout. It can also be a pair (tuple) of
                                 (connection, read) timeouts.
        :type _request_timeout: int, tuple(int, int), optional
        :param _request_auth: set to override the auth_settings for an a single
                              request; this effectively ignores the
                              authentication in the spec for a single request.
        :type _request_auth: dict, optional
        :param _content_type: force content-type for the request.
        :type _content_type: str, Optional
        :param _headers: set to override the headers for a single
                         request; this effectively ignores the headers
                         in the spec for a single request.
        :type _headers: dict, optional
        :param _host_index: set to override the host_index for a single
                            request; this effectively ignores the host_index
                            in the spec for a single request.
        :type _host_index: int, optional
        :return: Returns the result object.
        """ # noqa: E501

        _param = self._test_header_integer_boolean_string_enums_serialize(
            integer_header=integer_header,
            boolean_header=boolean_header,
            string_header=string_header,
            enum_nonref_string_header=enum_nonref_string_header,
            enum_ref_string_header=enum_ref_string_header,
            _request_auth=_request_auth,
            _content_type=_content_type,
            _headers=_headers,
            _host_index=_host_index
        )

        _response_types_map: Dict[str, Optional[str]] = {
            '200': "str",
        }
        response_data = self.api_client.call_api(
            *_param,
            _request_timeout=_request_timeout
        )
        response_data.read()
        return self.api_client.response_deserialize(
            response_data=response_data,
            response_types_map=_response_types_map,
        ).data


    @validate_call
    def test_header_integer_boolean_string_enums_with_http_info(
        self,
        integer_header: Optional[StrictInt] = None,
        boolean_header: Optional[StrictBool] = None,
        string_header: Optional[StrictStr] = None,
        enum_nonref_string_header: Optional[StrictStr] = None,
        enum_ref_string_header: Optional[StringEnumRef] = None,
        _request_timeout: Union[
            None,
            Annotated[StrictFloat, Field(gt=0)],
            Tuple[
                Annotated[StrictFloat, Field(gt=0)],
                Annotated[StrictFloat, Field(gt=0)]
            ]
        ] = None,
        _request_auth: Optional[Dict[StrictStr, Any]] = None,
        _content_type: Optional[StrictStr] = None,
        _headers: Optional[Dict[StrictStr, Any]] = None,
        _host_index: Annotated[StrictInt, Field(ge=0, le=0)] = 0,
    ) -> ApiResponse[str]:
        """Test header parameter(s)

        Test header parameter(s)

        :param integer_header:
        :type integer_header: int
        :param boolean_header:
        :type boolean_header: bool
        :param string_header:
        :type string_header: str
        :param enum_nonref_string_header:
        :type enum_nonref_string_header: str
        :param enum_ref_string_header:
        :type enum_ref_string_header: StringEnumRef
        :param _request_timeout: timeout setting for this request. If one
                                 number provided, it will be total request
                                 timeout. It can also be a pair (tuple) of
                                 (connection, read) timeouts.
        :type _request_timeout: int, tuple(int, int), optional
        :param _request_auth: set to override the auth_settings for an a single
                              request; this effectively ignores the
                              authentication in the spec for a single request.
        :type _request_auth: dict, optional
        :param _content_type: force content-type for the request.
        :type _content_type: str, Optional
        :param _headers: set to override the headers for a single
                         request; this effectively ignores the headers
                         in the spec for a single request.
        :type _headers: dict, optional
        :param _host_index: set to override the host_index for a single
                            request; this effectively ignores the host_index
                            in the spec for a single request.
        :type _host_index: int, optional
        :return: Returns the result object.
        """ # noqa: E501

        _param = self._test_header_integer_boolean_string_enums_serialize(
            integer_header=integer_header,
            boolean_header=boolean_header,
            string_header=string_header,
            enum_nonref_string_header=enum_nonref_string_header,
            enum_ref_string_header=enum_ref_string_header,
            _request_auth=_request_auth,
            _content_type=_content_type,
            _headers=_headers,
            _host_index=_host_index
        )

        _response_types_map: Dict[str, Optional[str]] = {
            '200': "str",
        }
        response_data = self.api_client.call_api(
            *_param,
            _request_timeout=_request_timeout
        )
        response_data.read()
        return self.api_client.response_deserialize(
            response_data=response_data,
            response_types_map=_response_types_map,
        )


    @validate_call
    def test_header_integer_boolean_string_enums_without_preload_content(
        self,
        integer_header: Optional[StrictInt] = None,
        boolean_header: Optional[StrictBool] = None,
        string_header: Optional[StrictStr] = None,
        enum_nonref_string_header: Optional[StrictStr] = None,
        enum_ref_string_header: Optional[StringEnumRef] = None,
        _request_timeout: Union[
            None,
            Annotated[StrictFloat, Field(gt=0)],
            Tuple[
                Annotated[StrictFloat, Field(gt=0)],
                Annotated[StrictFloat, Field(gt=0)]
            ]
        ] = None,
        _request_auth: Optional[Dict[StrictStr, Any]] = None,
        _content_type: Optional[StrictStr] = None,
        _headers: Optional[Dict[StrictStr, Any]] = None,
        _host_index: Annotated[StrictInt, Field(ge=0, le=0)] = 0,
    ) -> RESTResponseType:
        """Test header parameter(s)

        Test header parameter(s)

        :param integer_header:
        :type integer_header: int
        :param boolean_header:
        :type boolean_header: bool
        :param string_header:
        :type string_header: str
        :param enum_nonref_string_header:
        :type enum_nonref_string_header: str
        :param enum_ref_string_header:
        :type enum_ref_string_header: StringEnumRef
        :param _request_timeout: timeout setting for this request. If one
                                 number provided, it will be total request
                                 timeout. It can also be a pair (tuple) of
                                 (connection, read) timeouts.
        :type _request_timeout: int, tuple(int, int), optional
        :param _request_auth: set to override the auth_settings for an a single
                              request; this effectively ignores the
                              authentication in the spec for a single request.
        :type _request_auth: dict, optional
        :param _content_type: force content-type for the request.
        :type _content_type: str, Optional
        :param _headers: set to override the headers for a single
                         request; this effectively ignores the headers
                         in the spec for a single request.
        :type _headers: dict, optional
        :param _host_index: set to override the host_index for a single
                            request; this effectively ignores the host_index
                            in the spec for a single request.
        :type _host_index: int, optional
        :return: Returns the result object.
        """ # noqa: E501

        _param = self._test_header_integer_boolean_string_enums_serialize(
            integer_header=integer_header,
            boolean_header=boolean_header,
            string_header=string_header,
            enum_nonref_string_header=enum_nonref_string_header,
            enum_ref_string_header=enum_ref_string_header,
            _request_auth=_request_auth,
            _content_type=_content_type,
            _headers=_headers,
            _host_index=_host_index
        )

        _response_types_map: Dict[str, Optional[str]] = {
            '200': "str",
        }
        response_data = self.api_client.call_api(
            *_param,
            _request_timeout=_request_timeout
        )
        return response_data.response


    def _test_header_integer_boolean_string_enums_serialize(
        self,
        integer_header,
        boolean_header,
        string_header,
        enum_nonref_string_header,
        enum_ref_string_header,
        _request_auth,
        _content_type,
        _headers,
        _host_index,
    ) -> Tuple:

        _host = None

        _collection_formats: Dict[str, str] = {
        }

        _path_params: Dict[str, str] = {}
        _query_params: List[Tuple[str, str]] = []
        _header_params: Dict[str, Optional[str]] = _headers or {}
        _form_params: List[Tuple[str, str]] = []
        _files: Dict[str, str] = {}
        _body_params: Optional[bytes] = None

        # process the path parameters
        # process the query parameters
        # process the header parameters
        if integer_header is not None:
            _header_params['integer_header'] = integer_header
        if boolean_header is not None:
            _header_params['boolean_header'] = boolean_header
        if string_header is not None:
            _header_params['string_header'] = string_header
        if enum_nonref_string_header is not None:
            _header_params['enum_nonref_string_header'] = enum_nonref_string_header
        if enum_ref_string_header is not None:
            _header_params['enum_ref_string_header'] = enum_ref_string_header
        # process the form parameters
        # process the body parameter


        # set the HTTP header `Accept`
        _header_params['Accept'] = self.api_client.select_header_accept(
            [
                'text/plain'
            ]
        )


        # authentication setting
        _auth_settings: List[str] = [
        ]

        return self.api_client.param_serialize(
            method='GET',
            resource_path='/header/integer/boolean/string/enums',
            path_params=_path_params,
            query_params=_query_params,
            header_params=_header_params,
            body=_body_params,
            post_params=_form_params,
            files=_files,
            auth_settings=_auth_settings,
            collection_formats=_collection_formats,
            _host=_host,
            _request_auth=_request_auth
        )


