/**
 * OpenAPI Petstore
 * This is a sample server Petstore server. For this sample, you can use the api key `special-key` to test the authorization filters.
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * NOTE: This class is auto generated by OpenAPI-Generator 7.2.0-SNAPSHOT.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */



#include "CppRestPetstoreClient/model/Pet.h"

namespace org {
namespace openapitools {
namespace client {
namespace model {



Pet::Pet()
{
    m_Id = 0L;
    m_IdIsSet = false;
    m_CategoryIsSet = false;
    m_Name = utility::conversions::to_string_t("");
    m_NameIsSet = false;
    m_PhotoUrlsIsSet = false;
    m_TagsIsSet = false;
    m_Status = utility::conversions::to_string_t("");
    m_StatusIsSet = false;
}

Pet::~Pet()
{
}

void Pet::validate()
{
    // TODO: implement validation
}

web::json::value Pet::toJson() const
{

    web::json::value val = web::json::value::object();
    
    if(m_IdIsSet)
    {
        val[utility::conversions::to_string_t(U("id"))] = ModelBase::toJson(m_Id);
    }
    if(m_CategoryIsSet)
    {
        val[utility::conversions::to_string_t(U("category"))] = ModelBase::toJson(m_Category);
    }
    if(m_NameIsSet)
    {
        val[utility::conversions::to_string_t(U("name"))] = ModelBase::toJson(m_Name);
    }
    if(m_PhotoUrlsIsSet)
    {
        val[utility::conversions::to_string_t(U("photoUrls"))] = ModelBase::toJson(m_PhotoUrls);
    }
    if(m_TagsIsSet)
    {
        val[utility::conversions::to_string_t(U("tags"))] = ModelBase::toJson(m_Tags);
    }
    if(m_StatusIsSet)
    {
        val[utility::conversions::to_string_t(U("status"))] = ModelBase::toJson(m_Status);
    }

    return val;
}

bool Pet::fromJson(const web::json::value& val)
{
    bool ok = true;
    
    if(val.has_field(utility::conversions::to_string_t(U("id"))))
    {
        const web::json::value& fieldValue = val.at(utility::conversions::to_string_t(U("id")));
        if(!fieldValue.is_null())
        {
            int64_t refVal_setId;
            ok &= ModelBase::fromJson(fieldValue, refVal_setId);
            setId(refVal_setId);
        }
    }
    if(val.has_field(utility::conversions::to_string_t(U("category"))))
    {
        const web::json::value& fieldValue = val.at(utility::conversions::to_string_t(U("category")));
        if(!fieldValue.is_null())
        {
            std::shared_ptr<Category> refVal_setCategory;
            ok &= ModelBase::fromJson(fieldValue, refVal_setCategory);
            setCategory(refVal_setCategory);
        }
    }
    if(val.has_field(utility::conversions::to_string_t(U("name"))))
    {
        const web::json::value& fieldValue = val.at(utility::conversions::to_string_t(U("name")));
        if(!fieldValue.is_null())
        {
            utility::string_t refVal_setName;
            ok &= ModelBase::fromJson(fieldValue, refVal_setName);
            setName(refVal_setName);
        }
    }
    if(val.has_field(utility::conversions::to_string_t(U("photoUrls"))))
    {
        const web::json::value& fieldValue = val.at(utility::conversions::to_string_t(U("photoUrls")));
        if(!fieldValue.is_null())
        {
            std::vector<utility::string_t> refVal_setPhotoUrls;
            ok &= ModelBase::fromJson(fieldValue, refVal_setPhotoUrls);
            setPhotoUrls(refVal_setPhotoUrls);
        }
    }
    if(val.has_field(utility::conversions::to_string_t(U("tags"))))
    {
        const web::json::value& fieldValue = val.at(utility::conversions::to_string_t(U("tags")));
        if(!fieldValue.is_null())
        {
            std::vector<std::shared_ptr<Tag>> refVal_setTags;
            ok &= ModelBase::fromJson(fieldValue, refVal_setTags);
            setTags(refVal_setTags);
        }
    }
    if(val.has_field(utility::conversions::to_string_t(U("status"))))
    {
        const web::json::value& fieldValue = val.at(utility::conversions::to_string_t(U("status")));
        if(!fieldValue.is_null())
        {
            utility::string_t refVal_setStatus;
            ok &= ModelBase::fromJson(fieldValue, refVal_setStatus);
            setStatus(refVal_setStatus);
        }
    }
    return ok;
}

void Pet::toMultipart(std::shared_ptr<MultipartFormData> multipart, const utility::string_t& prefix) const
{
    utility::string_t namePrefix = prefix;
    if(namePrefix.size() > 0 && namePrefix.substr(namePrefix.size() - 1) != utility::conversions::to_string_t(U(".")))
    {
        namePrefix += utility::conversions::to_string_t(U("."));
    }
    if(m_IdIsSet)
    {
        multipart->add(ModelBase::toHttpContent(namePrefix + utility::conversions::to_string_t(U("id")), m_Id));
    }
    if(m_CategoryIsSet)
    {
        multipart->add(ModelBase::toHttpContent(namePrefix + utility::conversions::to_string_t(U("category")), m_Category));
    }
    if(m_NameIsSet)
    {
        multipart->add(ModelBase::toHttpContent(namePrefix + utility::conversions::to_string_t(U("name")), m_Name));
    }
    if(m_PhotoUrlsIsSet)
    {
        multipart->add(ModelBase::toHttpContent(namePrefix + utility::conversions::to_string_t(U("photoUrls")), m_PhotoUrls));
    }
    if(m_TagsIsSet)
    {
        multipart->add(ModelBase::toHttpContent(namePrefix + utility::conversions::to_string_t(U("tags")), m_Tags));
    }
    if(m_StatusIsSet)
    {
        multipart->add(ModelBase::toHttpContent(namePrefix + utility::conversions::to_string_t(U("status")), m_Status));
    }
}

bool Pet::fromMultiPart(std::shared_ptr<MultipartFormData> multipart, const utility::string_t& prefix)
{
    bool ok = true;
    utility::string_t namePrefix = prefix;
    if(namePrefix.size() > 0 && namePrefix.substr(namePrefix.size() - 1) != utility::conversions::to_string_t(U(".")))
    {
        namePrefix += utility::conversions::to_string_t(U("."));
    }

    if(multipart->hasContent(utility::conversions::to_string_t(U("id"))))
    {
        int64_t refVal_setId;
        ok &= ModelBase::fromHttpContent(multipart->getContent(utility::conversions::to_string_t(U("id"))), refVal_setId );
        setId(refVal_setId);
    }
    if(multipart->hasContent(utility::conversions::to_string_t(U("category"))))
    {
        std::shared_ptr<Category> refVal_setCategory;
        ok &= ModelBase::fromHttpContent(multipart->getContent(utility::conversions::to_string_t(U("category"))), refVal_setCategory );
        setCategory(refVal_setCategory);
    }
    if(multipart->hasContent(utility::conversions::to_string_t(U("name"))))
    {
        utility::string_t refVal_setName;
        ok &= ModelBase::fromHttpContent(multipart->getContent(utility::conversions::to_string_t(U("name"))), refVal_setName );
        setName(refVal_setName);
    }
    if(multipart->hasContent(utility::conversions::to_string_t(U("photoUrls"))))
    {
        std::vector<utility::string_t> refVal_setPhotoUrls;
        ok &= ModelBase::fromHttpContent(multipart->getContent(utility::conversions::to_string_t(U("photoUrls"))), refVal_setPhotoUrls );
        setPhotoUrls(refVal_setPhotoUrls);
    }
    if(multipart->hasContent(utility::conversions::to_string_t(U("tags"))))
    {
        std::vector<std::shared_ptr<Tag>> refVal_setTags;
        ok &= ModelBase::fromHttpContent(multipart->getContent(utility::conversions::to_string_t(U("tags"))), refVal_setTags );
        setTags(refVal_setTags);
    }
    if(multipart->hasContent(utility::conversions::to_string_t(U("status"))))
    {
        utility::string_t refVal_setStatus;
        ok &= ModelBase::fromHttpContent(multipart->getContent(utility::conversions::to_string_t(U("status"))), refVal_setStatus );
        setStatus(refVal_setStatus);
    }
    return ok;
}

int64_t Pet::getId() const
{
    return m_Id;
}

void Pet::setId(int64_t value)
{
    m_Id = value;
    m_IdIsSet = true;
}

bool Pet::idIsSet() const
{
    return m_IdIsSet;
}

void Pet::unsetId()
{
    m_IdIsSet = false;
}
std::shared_ptr<Category> Pet::getCategory() const
{
    return m_Category;
}

void Pet::setCategory(const std::shared_ptr<Category>& value)
{
    m_Category = value;
    m_CategoryIsSet = true;
}

bool Pet::categoryIsSet() const
{
    return m_CategoryIsSet;
}

void Pet::unsetCategory()
{
    m_CategoryIsSet = false;
}
utility::string_t Pet::getName() const
{
    return m_Name;
}

void Pet::setName(const utility::string_t& value)
{
    m_Name = value;
    m_NameIsSet = true;
}

bool Pet::nameIsSet() const
{
    return m_NameIsSet;
}

void Pet::unsetName()
{
    m_NameIsSet = false;
}
std::vector<utility::string_t>& Pet::getPhotoUrls()
{
    return m_PhotoUrls;
}

void Pet::setPhotoUrls(const std::vector<utility::string_t>& value)
{
    m_PhotoUrls = value;
    m_PhotoUrlsIsSet = true;
}

bool Pet::photoUrlsIsSet() const
{
    return m_PhotoUrlsIsSet;
}

void Pet::unsetPhotoUrls()
{
    m_PhotoUrlsIsSet = false;
}
std::vector<std::shared_ptr<Tag>>& Pet::getTags()
{
    return m_Tags;
}

void Pet::setTags(const std::vector<std::shared_ptr<Tag>>& value)
{
    m_Tags = value;
    m_TagsIsSet = true;
}

bool Pet::tagsIsSet() const
{
    return m_TagsIsSet;
}

void Pet::unsetTags()
{
    m_TagsIsSet = false;
}
utility::string_t Pet::getStatus() const
{
    return m_Status;
}

void Pet::setStatus(const utility::string_t& value)
{
    m_Status = value;
    m_StatusIsSet = true;
}

bool Pet::statusIsSet() const
{
    return m_StatusIsSet;
}

void Pet::unsetStatus()
{
    m_StatusIsSet = false;
}
}
}
}
}


