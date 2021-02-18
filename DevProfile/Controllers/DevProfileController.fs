namespace DevProfile.Controllers

open Microsoft.AspNetCore.Mvc
open DevProfile.Repositories
open DevProfile.Models
open System

[<Controller>]
[<Route("dev-profile")>]
type DevProfileControler(repo: IDevProfileRepository) =
    inherit ControllerBase()
    
    [<HttpGet("{email}")>]
    member __.GetDevProfile([<FromRoute>] email: string) : IActionResult =
        let profile = repo.GetProfileByEmail(email)
        match profile with
        | Some(x) -> OkObjectResult(profile) :> IActionResult
        | None -> NotFoundResult() :> IActionResult


    [<HttpGet("seed")>]
    member __.SeedData() = 
        raise (NotImplementedException())

        let profile = DevProfile()
        profile.ProfileName <- "Abner F"
        profile.ProfileBio <- "Just a dev random bio"
        profile.ProfileBirthDay <- new DateTime(1996, 6, 9)
        profile.ProfileEmail <- "contact@abnerfs.dev"
        profile.ProfileLinks <- [|
            DevProfileLink(
                LinkOrder = 1,
                LinkPlatform = "GitHub",
                LinkUrl = "https://github.com/abnerfs"
            )
        |]
        profile.ProfileExps <- [|
            DevProfileExp(
                ExpName = "FullStack Developer at ORGM",
                ExpDescription = "Doing a lot of stuff",
                ExpStartYear = 2015,
                ExpStartMonth = 10,
                ExpEndYear = 2020,
                ExpEndMonth = 1
            )
        |]

        profile.ProfileSkills <- [|
            DevProfileSkills(
                SkillName = "C#",
                SkillValue = 10
            )
            DevProfileSkills(
                SkillName = "F#",
                SkillValue = 2
            )
        |]


        repo.Insert(profile) |> ignore
        
