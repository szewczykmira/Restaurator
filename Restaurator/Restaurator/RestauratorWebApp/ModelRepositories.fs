﻿namespace FsWeb.Repositories

type UserRepository() =
    member x.GetAll () = 
        use context = new RestauratorContext() 
        query { for g in context.Users do
                select g }
        |> Seq.toList
    member x.Add elem =
        use context = new RestauratorContext ()
        context.Users.Add elem |> ignore;
        context.SaveChanges() |> ignore

type RestaurantRepository() =
    member x.GetAll () = 
        use context = new RestauratorContext() 
        query { for g in context.Restaurants do
                select g }
        |> Seq.toList

type OpinionRepository() =
    member x.GetAll () = 
        use context = new RestauratorContext() 
        query { for g in context.Opinions do
                select g }
        |> Seq.toList

