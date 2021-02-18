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

type Startup(configuration: IConfiguration) =
    member _.Configuration = configuration


    // This method gets called by the runtime. Use this method to add services to the container.
    member _.ConfigureServices(services: IServiceCollection) =
        let mongoCnString = configuration.GetSection("MongoConfig").Get<DatabaseConfig>();

        services.AddTransient<DatabaseConfig>(fun _ -> mongoCnString) |> ignore
        services.AddTransient<IDevProfileRepository, DevProfileRepository>() |> ignore
        services.AddTransient<IDbService, DbService>() |> ignore


        // Add framework services.
        services.AddControllers() |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        app.UseRouting()
           .UseAuthorization()
           .UseEndpoints(fun endpoints ->
                 endpoints.MapControllers() |> ignore
             ) |> ignore
