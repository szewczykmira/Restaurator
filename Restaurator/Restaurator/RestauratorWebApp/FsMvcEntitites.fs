namespace FsWeb.Repositories

open System.Data.Entity
open FsWeb.Models

type MyContext() =
    inherit DbContext("server=some;database=dbname;user id=uid;password=pwd")

    [<DefaultValue>] val mutable users : DbSet<User>
    member x.Users with get() = x.users and set v = x.users <- v

    [<DefaultValue>] val mutable restaurants : DbSet<Restaurant>
    member x.Restaurants with get() = x.restaurants and set v = x.restaurants <- v

    [<DefaultValue>] val mutable opinions : DbSet<Opinion>
    member x.Opinions with get() = x.opinions and set v = x.opinions <- v

