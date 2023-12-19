/**
 * OpenAPI Petstore
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI-Generator 7.2.0-SNAPSHOT.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

/*
 * FileSchemaTestClass.h
 *
 * 
 */

#ifndef FileSchemaTestClass_H_
#define FileSchemaTestClass_H_



#include "File.h"
#include <vector>
#include <memory>
#include <vector>
#include <boost/property_tree/ptree.hpp>
#include "helpers.h"

namespace org {
namespace openapitools {
namespace server {
namespace model {

/// <summary>
/// 
/// </summary>
class  FileSchemaTestClass 
{
public:
    FileSchemaTestClass() = default;
    explicit FileSchemaTestClass(boost::property_tree::ptree const& pt);
    virtual ~FileSchemaTestClass() = default;

    FileSchemaTestClass(const FileSchemaTestClass& other) = default; // copy constructor
    FileSchemaTestClass(FileSchemaTestClass&& other) noexcept = default; // move constructor

    FileSchemaTestClass& operator=(const FileSchemaTestClass& other) = default; // copy assignment
    FileSchemaTestClass& operator=(FileSchemaTestClass&& other) noexcept = default; // move assignment

    std::string toJsonString(bool prettyJson = false) const;
    void fromJsonString(std::string const& jsonString);
    boost::property_tree::ptree toPropertyTree() const;
    void fromPropertyTree(boost::property_tree::ptree const& pt);


    /////////////////////////////////////////////
    /// FileSchemaTestClass members

    /// <summary>
    /// 
    /// </summary>
    File getFile() const;
    void setFile(File value);

    /// <summary>
    /// 
    /// </summary>
    std::vector<File> getFiles() const;
    void setFiles(std::vector<File> value);

protected:
    File m_file;
    std::vector<File> m_Files;
};

std::vector<FileSchemaTestClass> createFileSchemaTestClassVectorFromJsonString(const std::string& json);

template<>
inline boost::property_tree::ptree toPt<FileSchemaTestClass>(const FileSchemaTestClass& val) {
    return val.toPropertyTree();
}

template<>
inline FileSchemaTestClass fromPt<FileSchemaTestClass>(const boost::property_tree::ptree& pt) {
    FileSchemaTestClass ret;
    ret.fromPropertyTree(pt);
    return ret;
}

}
}
}
}

#endif /* FileSchemaTestClass_H_ */
