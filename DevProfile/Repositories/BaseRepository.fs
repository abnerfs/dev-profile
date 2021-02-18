namespace DevProfile.Repositories
open MongoDB.Driver
open DevProfile.Services

type BaseRepository<'T>(dbService: IDbService, collectionName: string) =
    let mutable collection : IMongoCollection<'T> = null

    member __.Collection = 
        collection <- 
            if (collection = null) then dbService.OpenConnection().GetCollection<'T>(collectionName) else (collection)

        collection

    member __.Filter = Builders<'T>.Filter

