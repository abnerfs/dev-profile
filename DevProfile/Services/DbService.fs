namespace DevProfile.Services

open MongoDB.Driver
open DevProfile.Config


type IDbService = 
    abstract OpenConnection : unit -> IMongoDatabase

type DbService(config: DatabaseConfig) =
    interface IDbService with
        member __.OpenConnection() : IMongoDatabase =
            let client = MongoClient(config.Url)
            let db = client.GetDatabase(config.Database)
            db