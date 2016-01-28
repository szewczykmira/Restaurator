namespace FsWeb.Models

open System
open System.Collections.Generic
open System.Data.Entity
open System.ComponentModel.DataAnnotations

type User () =
    let mutable firstName = ""
    let mutable email = ""
    let mutable pswd = ""
    let mutable res = Unchecked.defaultof<ICollection<Restaurant>>
    let mutable opi = Unchecked.defaultof<ICollection<Opinion>>
    
    [<Key>]
    member val Id = Guid.NewGuid() with get, set

    [<Required>]
    [<Display(Name = "First Name")>]
    member x.FirstName with get() = firstName and set v = firstName <- v

    [<Required>]
    [<EmailAddress>]
    [<DataType(DataType.EmailAddress)>]
    [<Display(Name = "Email")>]
    member x.Email with get() = email and set e = email <- e


    [<Required>]
    [<MinLength(10)>]
    [<DataType(DataType.Password)>]
    [<Display(Name = "Password")>]
    member x.Password with get () = pswd and set p = pswd <- p

    abstract member Restaurant : ICollection<Restaurant> with get, set
    override x.Restaurant with get() = res and set v = res <- v

    abstract member Opinion : ICollection<Opinion> with get, set
    override x.Opinion with get() = opi and set v = opi <- v


and Restaurant () =
    let mutable name = ""
    let mutable dscr = ""
    let mutable adr = ""
    let mutable uid = 0
    let mutable user = Unchecked.defaultof<User>
    let mutable opi = Unchecked.defaultof<ICollection<Opinion>>

    [<Key>] 
    member val Id = Guid.NewGuid() with get, set

    [<Required>]
    [<Display(Name = "Name")>]
    member this.Name with get() = name and set v = name <- v

    [<Required>]
    [<Display(Name="Description")>]
    member this.Description with get() = dscr and set v = dscr <- v

    [<Required>]
    [<Display(Name="Address")>]
    member this.Address with get () = adr and set v = adr <- v

    member x.User with get() = user and set v = user <- v
    member x.UserId with get() = uid and set v = uid <- v

    abstract member Opinion : ICollection<Opinion> with get, set
    override x.Opinion with get() = opi and set v = opi <- v


and Opinion () =
    let mutable scr = 1
    let mutable uid =  1
    let mutable dscr = ""
    let mutable uid = 0
    let mutable user = Unchecked.defaultof<User>
    let mutable rid = 0
    let mutable rest = Unchecked.defaultof<Restaurant>

    [<Key>] 
    member val Id = Guid.NewGuid() with get, set

    [<Required>]
    [<Display(Name = "Score")>]
    [<Range(1,6)>]
    member this.Score with get () = scr and set v = scr <- v

    [<Required>]
    [<Display(Name="Description")>]
    member this.Description with get() = dscr and set v = dscr <- v

    member x.User with get() = user and set v = user <- v
    member x.UserId with get() = uid and set v = uid <- v

    member x.Restaurant with get() = rest and set v = rest <- v
    member x.RestaurantId with get() = rid and set v = rid <- v
