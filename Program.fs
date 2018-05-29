
open Fable.Remoting.Json
open Newtonsoft.Json
open System

let fable = Fable.JsonConverter()
let remoting = FableJsonConverter()

let parse<'a> (converter:JsonConverter) value =
    try
        let result = JsonConvert.DeserializeObject(value, typeof<'a>, converter)
        printfn "Success: %s -> %A" value result
    with ex ->
        printfn "Failed: %s, %s" value ex.Message

[<EntryPoint>]
let main argv =
    printfn "Fable.JsonConverter"
    parse<int> fable "\"5\""
    parse<int> fable "\"+5\""
    parse<int> fable "5"
    parse<int> fable "\"text\""
    parse<int64> fable "\"5\""
    parse<int64> fable "\"+5\""
    parse<int64> fable "5"
    parse<int64> fable "\"text\""
    parse<int64> fable "{low: 41, high: 0, unsigned: false}"

    printfn "--"

    printfn "Fable.Remoting"
    parse<int> remoting "\"5\""
    parse<int> remoting "\"+5\""
    parse<int> remoting "5"
    parse<int> remoting "\"text\""
    parse<int64> remoting "\"5\""
    parse<int64> remoting "\"+5\""
    parse<int64> remoting "5"
    parse<int64> remoting "\text\""
    parse<int64> remoting "{low: 41, high: 0, unsigned: false}"

    0
