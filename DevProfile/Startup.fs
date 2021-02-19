namespace DevProfile

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open DevProfile.Config
open DevProfile.Models
open DevProfile.Services
open DevProfile.Repositories
open DevProfile.Responses


type Startup(configuration: IConfiguration, env: IHostEnvironment) =
    do
        ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", true).AddEnvironmentVariables() |> ignore


    member _.Configuration = configuration


    // This method gets called by the runtime. Use this method to add services to the container.
    member _.ConfigureServices(services: IServiceCollection) =
        let mongoCnString = configuration.GetSection("MongoConfig").Get<DatabaseConfig>();

        services.AddTransient<DatabaseConfig>(fun _ -> mongoCnString) |> ignore
        services.AddTransient<IDevProfileRepository, DevProfileRepository>() |> ignore
        services.AddTransient<IDbService, DbService>() |> ignore

        let config = AutoMapper.MapperConfiguration(fun cfg -> 
            cfg.CreateMap<DevProfile.Models.DevProfile, DevProfileResponse>() |> ignore
            cfg.CreateMap<DevProfile.Models.DevProfileLink, DevProfileLinkResponse>() |> ignore
            cfg.CreateMap<DevProfile.Models.DevProfileExp, DevProfileExpResponse>() |> ignore
            cfg.CreateMap<DevProfile.Models.DevProfileSkill, DevProfileSkillResponse>() |> ignore
        )

        let mapper = config.CreateMapper()
        services.AddSingleton(mapper) |> ignore

        // Add framework services.
        services.AddControllers() |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        //if (env.IsDevelopment()) then
        app.UseDeveloperExceptionPage() |> ignore

        app.UseRouting()
           .UseAuthorization()
           .UseEndpoints(fun endpoints ->
                 endpoints.MapControllers() |> ignore
             ) |> ignore
