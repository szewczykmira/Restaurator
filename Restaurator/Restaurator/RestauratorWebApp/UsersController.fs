namespace FsWeb.UsersController

open System.Web
open System.Web.Mvc
open FsWeb.Models
open FsWeb.Repositories
open FsWeb.AuthorizedActionFilter


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
        | true -> repository.Add user; upcast base.RedirectToAction("Index", "Home")

    member this.Login() =
        this.View() :> ActionResult

    [<HttpPost>]
    [<ValidateAntiForgeryToken>]
    member this.Login (Email, Password) =
        let isValidUser = repository.Exist Email Password

        match isValidUser with
        | true ->
            let user = repository.GetByNamePasswd Email Password
            this.Session.["User"] <- user.Email
            this.RedirectToAction("Index", "Home") :> ActionResult
        | false -> 
            this.ModelState.AddModelError("", "Invalid login attempt")
            this.View(Email, Password) :> ActionResult

    [<AuthorizedActionFilter>]
    member this.Logout () =
        this.Session.["User"] <- null
        this.RedirectToAction("Index", "Home")
        


