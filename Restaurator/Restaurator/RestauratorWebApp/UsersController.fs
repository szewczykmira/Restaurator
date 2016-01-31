namespace FsWeb.UsersController

open System.Web
open System.Web.Mvc
open FsWeb.Models
open FsWeb.Repositories

[<HandleError>]
type UsersController(repository : UserRepository) =
    inherit Controller()
    new() = new UsersController(UserRepository())
    member this.Index() =
        this.View() :> ActionResult
    [<HttpGet>]
    member this.Create() =
        this.View() :> ActionResult
    [<HttpPost>]
    member this.Create(user:User):ActionResult =
        match base.ModelState.IsValid with
        | false -> upcast this.View user
        | true -> upcast base.RedirectToAction("Index")


