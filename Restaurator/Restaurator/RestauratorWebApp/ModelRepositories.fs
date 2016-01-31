namespace FsWeb.Repositories

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

    member x.Exist usr pswd =
        use context = new RestauratorContext()
        let lst = query { for g in context.Users do
                             where (g.Email = usr && g.Password = pswd)}
                        |> Seq.toList
        match (lst.Length) with
        | 0 -> false
        | _ -> true

    member x.GetByNamePasswd usr pswd =
        use context = new RestauratorContext()
        let lst = query {for u in context.Users do
                            where (u.Email = usr && u.Password = pswd)}
                            |> Seq.toList
        lst.Head


type RestaurantRepository() =
    member x.GetAll () = 
        use context = new RestauratorContext() 
        query { for g in context.Restaurants do
                select g }
        |> Seq.toList
    member x.Add elem =
        use context = new RestauratorContext ()
        context.Restaurants.Add elem |> ignore;
        context.SaveChanges() |> ignore

    member x.GetUsers () = 
        use context = new RestauratorContext ()
        query { for g in context.Users do
                select g }
        |> Seq.toList

    member x.GetById id =
        use context = new RestauratorContext ()
        let lst = query { for g in context.Restaurants do
                            where (g.Id = id)}
                        |> Seq.toList
        lst.Head

type OpinionRepository() =
    member x.GetAll () = 
        use context = new RestauratorContext() 
        query { for g in context.Opinions do
                select g }
        |> Seq.toList

    member x.Add elem =
        use context = new RestauratorContext ()
        context.Opinions.Add elem |> ignore;
        context.SaveChanges() |> ignore

