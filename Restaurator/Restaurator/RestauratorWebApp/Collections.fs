namespace FsWeb.Collections

module Collections =
    let inline init s =
        let coll = new ^t()
        Seq.iter (fun (k,v) -> (^t : (member Add: 'a * 'b -> unit) coll, k, v)) s
        coll

