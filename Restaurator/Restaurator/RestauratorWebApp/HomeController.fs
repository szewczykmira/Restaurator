namespace FsWeb.HomeController

open System.Web
open System
open System.Web.Mvc
open FsWeb.Models
open FsWeb.Repositories
open FsWeb.AuthorizedActionFilter

[<HandleError>]
type HomeController(repository : RestaurantRepository) =
    inherit Controller()
    new() = new HomeController(RestaurantRepository())
    member this.Index () =
        repository.GetAll ()
        |> this.View :> ActionResult

    [<HttpGet>]
    [<AuthorizedActionFilter>]
    member this.Create() =
        let (?<-) (viewData:ViewDataDictionary) (name:string) (value: 'T) = viewData.Add(name, value)
        this.ViewData?Users <- new SelectList(repository.GetUsers(), "Id", "Email")
        this.View () :> ActionResult
    
    [<HttpPost>]
    member this.Create(restaurant:Restaurant):ActionResult =
        let (?<-) (viewData:ViewDataDictionary) (name:string) (value: 'T) = viewData.Add(name, value)
        this.ViewData?Users <- new SelectList(repository.GetUsers(), "Id", "Email")
        match base.ModelState.IsValid with
        | false -> upcast this.View restaurant
        | true -> repository.Add restaurant; upcast base.RedirectToAction("Index", "Home")

    member this.Details(id) =
        let res = repository.GetById id
        let (?<-) (viewData:ViewDataDictionary) (name:string) (value: 'T) = viewData.Add(name, value)
        let id = Guid.Parse (res.UserId)
        this.ViewData?Owner <- (repository.GetOwner id).Email
        this.View (res) :> ActionResult

    member this.DisplayOpinion(id : Guid) =
        let (?<-) (viewData:ViewDataDictionary) (name:string) (value: 'T) = viewData.Add(name, value)
        this.ViewData?Restaurant <- (repository.GetById id).Name
        let nId = id.ToString()
        let model = repository.GetOpinion nId
        
        model |> this.View :> ActionResult
