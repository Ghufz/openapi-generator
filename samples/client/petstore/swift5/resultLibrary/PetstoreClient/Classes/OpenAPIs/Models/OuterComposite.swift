//
// OuterComposite.swift
//
// Generated by openapi-generator
// https://openapi-generator.tech
//

import Foundation


public struct OuterComposite: Codable { 


    public var myNumber: Double?
    public var myString: String?
    public var myBoolean: Bool?

    public init(myNumber: Double?, myString: String?, myBoolean: Bool?) {
        self.myNumber = myNumber
        self.myString = myString
        self.myBoolean = myBoolean
    }

    public enum CodingKeys: String, CodingKey, CaseIterable { 
        case myNumber = "my_number"
        case myString = "my_string"
        case myBoolean = "my_boolean"
    }

}
