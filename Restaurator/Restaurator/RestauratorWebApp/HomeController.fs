namespace FsWeb.Controllers

open System.Web
open System.Web.Mvc
open FsWeb.Models
open FsWeb.Repositories

[<HandleError>]
type HomeController(repository : RestaurantRepository) =
    inherit Controller()
    new() = new HomeController(RestaurantRepository())
    member this.Index () =
        this.View() :> ActionResult
