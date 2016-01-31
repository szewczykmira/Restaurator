namespace FsWeb.OpinionsController

open System.Web
open System
open System.Web.Mvc
open FsWeb.Models
open FsWeb.Repositories
open FsWeb.AuthorizedActionFilter


[<HandleError>]
type OpinionsController(repository : OpinionRepository) =
    inherit Controller()
    new() = new OpinionsController(OpinionRepository())

    [<HttpGet>]
    [<AuthorizedActionFilter>]
    member this.Create(id:string) =
        let (?<-) (viewData:ViewDataDictionary) (name:string) (value: 'T) = viewData.Add(name, value)
        this.ViewData?Restaurants <- new SelectList(repository.GetRestaurants(), "Id", "Name")
        this.ViewData?Users <- new SelectList(repository.GetUsers(), "Id", "Email")
        this.ViewData?Id <- id
        this.View () :> ActionResult

    [<HttpPost>]
    member this.Create(opinion:Opinion):ActionResult =
        let (?<-) (viewData:ViewDataDictionary) (name:string) (value: 'T) = viewData.Add(name, value)
        this.ViewData?Users <- new SelectList(repository.GetUsers(), "Id", "Email")
        this.ViewData?Restaurants <- new SelectList(repository.GetRestaurants(), "Id", "Name")
        match base.ModelState.IsValid with
        | false -> upcast this.View opinion
        | true -> 
            repository.Add opinion;
            upcast base.RedirectToAction("Index", "Home")

