namespace DevProfile.Config


type DatabaseConfig() =
    member val Url = "" with get, set
    member val Database = "" with get, set


