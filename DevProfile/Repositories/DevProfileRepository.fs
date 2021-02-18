namespace DevProfile.Repositories

open DevProfile.Services
open DevProfile.Models
open MongoDB.Driver
open MongoDB.Bson
open System.Linq
open Microsoft.FSharp.Linq


type IDevProfileRepository =
    abstract member GetProfile: string -> Option<DevProfile>
    abstract member GetProfileByEmail: string -> Option<DevProfile>
    abstract member Insert: DevProfile -> unit


type DevProfileRepository(db: IDbService) = 
    inherit BaseRepository<DevProfile>(db, "profiles")

    interface IDevProfileRepository with
        member __.GetProfileByEmail(email: string): Option<DevProfile>  = 
            let filter = __.Filter.Eq((fun x -> x.ProfileEmail), email)
            let result = __.Collection.Find(filter).ToEnumerable().ToArray() |> Array.tryExactlyOne
            result

        member __.GetProfile(id: string) : Option<DevProfile> = 
            let filter = __.Filter.Eq((fun x -> x.ProfileId), id)
            let user = __.Collection.Find(filter).ToEnumerable().ToArray() |> Array.tryExactlyOne
            user

        member __.Insert(profile: DevProfile) =
            __.Collection.InsertOne(profile) |> ignore
    
