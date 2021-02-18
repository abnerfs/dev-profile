namespace DevProfile.Repositories

open DevProfile.Services
open DevProfile.Models
open MongoDB.Driver
open MongoDB.Bson
open System.Linq


type IDevProfileRepository =
    abstract member GetProfile: string -> DevProfile
    abstract member Insert: DevProfile -> unit


type DevProfileRepository(db: IDbService) = 
    inherit BaseRepository<DevProfile>(db, "profiles")

    interface IDevProfileRepository with
        member __.GetProfile(id: string) : DevProfile = 
            let filter = __.Filter.Eq((fun x -> x.ProfileName), id)
            let user = __.Collection.Find(filter).ToEnumerable().First()
            user
        member __.Insert(profile: DevProfile) =
            __.Collection.InsertOne(profile) |> ignore
    
