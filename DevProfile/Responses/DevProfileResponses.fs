namespace DevProfile.Responses

open System.Text.Json.Serialization
open System


type DevProfileLinkResponse() =
    [<JsonPropertyName("link_id")>]
    member val LinkId : string = "" with get, set

    [<JsonPropertyName("link_url")>]
    member val LinkUrl : string = "" with get, set

    [<JsonPropertyName("link_platform")>]
    member val LinkPlatform : string = "" with get, set

    [<JsonPropertyName("link_order")>]
    member val LinkOrder : int = 0 with get, set

type DevProfileSkillResponse() =
    [<JsonPropertyName("skill_id")>]
    member val SkillId : string = "" with get, set

    [<JsonPropertyName("skill_name")>]
    member val SkillName : string = "" with get, set

    [<JsonPropertyName("skill_value")>]
    member val SkillValue : int = 0 with get, set

type DevProfileExpResponse() = 

    [<JsonPropertyName("exp_id")>]
    member val ExpId : string = "" with get, set

    [<JsonPropertyName("exp_name")>]
    member val ExpName : string = "" with get, set

    [<JsonPropertyName("exp_description")>]
    member val ExpDescription : string = "" with get, set

    [<JsonPropertyName("exp_start_month")>]
    member val ExpStartMonth : int = 0 with get, set

    [<JsonPropertyName("exp_start_year")>]
    member val ExpStartYear : int = 0 with get, set

    [<JsonPropertyName("exp_end_month")>]
    member val ExpEndMonth : int = 0 with get, set

    [<JsonPropertyName("exp_end_year")>]
    member val ExpEndYear : int = 0 with get, set

type DevProfileResponse() =
    [<JsonPropertyName("profile_id")>]
    member val ProfileId : string = "" with get, set

    [<JsonPropertyName("profile_name")>]
    member val ProfileName : string = "" with get, set
    
    [<JsonPropertyName("profile_email")>]
    member val ProfileEmail : string = "" with get, set

    [<JsonPropertyName("profile_bio")>]
    member val ProfileBio : string = "" with get, set

    [<JsonPropertyName("profile_birthday")>]
    member val ProfileBirthDay : Nullable<DateTime> = Unchecked.defaultof<Nullable<DateTime>> with get, set

    [<JsonPropertyName("profile_links")>]
    member val ProfileLinks : DevProfileLinkResponse[] = null with get, set

    [<JsonPropertyName("profile_skills")>]
    member val ProfileSkills : DevProfileSkillResponse[] = null with get, set

    [<JsonPropertyName("profile_exps")>]
    member val ProfileExps : DevProfileExpResponse[] = null with get, set
