using System.Collections;
using System.Collections.Generic;
using Network.Json;
using UnityEngine;

public class CardsJsonReceiver : JsonReceiverBase<CardsResult, CardsJsonReceiver>
{
    
}

public class CardsResult : Result
{
    public CardInfo results { get; set; }
}

public class CardInfo
{
    public  string id { get; set; }
    public  string name { get; set; }
    public  string type { get; set; }
    public  string epoch { get; set; }
    public  string costInfo { get; set; }
    public string requirementBuildCardId { get; set; }
    public string currentEffect { get; set; }
}
