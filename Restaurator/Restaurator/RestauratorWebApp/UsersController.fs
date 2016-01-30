namespace FsWeb.UsersController

open System.Web
open System.Web.Mvc
open FsWeb.Models
open FsWeb.Repositories

[<HandleError>]
type UsersController(repository : UserRepository) =
    inherit Controller()
    new() = new UsersController(UserRepository())
    member this.Create() =
        this.View() :> ActionResult

