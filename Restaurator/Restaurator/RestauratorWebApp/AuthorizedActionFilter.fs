namespace FsWeb.AuthorizedActionFilter

open System.Web.Mvc
open System.Web.Routing

open FsWeb.Collections.Collections

type AuthorizedActionFilter() =
    inherit ActionFilterAttribute ()
    override this.OnActionExecuting(filterContext : ActionExecutingContext) =
        if filterContext.HttpContext.Session.["User"] = null then
            let routeValueDict = init ["action", "Login"; "controller", "Users"] : RouteValueDictionary
            filterContext.Result <- RedirectToRouteResult(RouteValueDictionary(routeValueDict))

