namespace DevProfile.Models

open System
open MongoDB.Bson.Serialization.Attributes
open MongoDB.Bson

type DevProfileLink() =
    [<BsonId>]
    [<BsonRepresentation(BsonType.ObjectId)>]
    member val LinkId : string = ObjectId.GenerateNewId().ToString() with get, set

    [<BsonElement("link_url")>]
    member val LinkUrl : string = "" with get, set

    [<BsonElement("link_platform")>]
    member val LinkPlatform : string = "" with get, set

    [<BsonElement("link_order")>]
    member val LinkOrder : int = 0 with get, set

type DevProfileSkill() =
    [<BsonId>]
    [<BsonRepresentation(BsonType.ObjectId)>]
    member val SkillId : string = ObjectId.GenerateNewId().ToString() with get, set

    [<BsonElement("skill_name")>]
    member val SkillName : string = "" with get, set

    [<BsonElement("skill_value")>]
    member val SkillValue : int = 0 with get, set

type DevProfileExp() = 

    [<BsonId>]
    [<BsonRepresentation(BsonType.ObjectId)>]
    member val ExpId : string = ObjectId.GenerateNewId().ToString() with get, set

    [<BsonElement("exp_name")>]
    member val ExpName : string = "" with get, set

    [<BsonElement("exp_description")>]
    member val ExpDescription : string = "" with get, set

    [<BsonElement("exp_start_month")>]
    member val ExpStartMonth : int = 0 with get, set

    [<BsonElement("exp_start_year")>]
    member val ExpStartYear : int = 0 with get, set

    [<BsonElement("exp_end_month")>]
    member val ExpEndMonth : int = 0 with get, set

    [<BsonElement("exp_end_year")>]
    member val ExpEndYear : int = 0 with get, set

type DevProfile() =
    [<BsonId>]
    [<BsonRepresentation(BsonType.ObjectId)>]
    member val ProfileId : string = ObjectId.GenerateNewId().ToString() with get, set

    [<BsonElement("profile_name")>]
    member val ProfileName : string = "" with get, set
    
    [<BsonElement("profile_email")>]
    member val ProfileEmail : string = "" with get, set

    [<BsonElement("profile_bio")>]
    member val ProfileBio : string = "" with get, set

    [<BsonElement("profile_birthday")>]
    member val ProfileBirthDay : Nullable<DateTime> = Unchecked.defaultof<Nullable<DateTime>> with get, set

    [<BsonElement("profile_links")>]
    member val ProfileLinks : DevProfileLink[] = null with get, set

    [<BsonElement("profile_skills")>]
    member val ProfileSkills : DevProfileSkill[] = null with get, set

    [<BsonElement("profile_exps")>]
    member val ProfileExps : DevProfileExp[] = null with get, set
