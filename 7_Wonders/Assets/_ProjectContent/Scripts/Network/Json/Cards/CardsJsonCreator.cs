using System.Collections;
using System.Collections.Generic;
using Network.Json;
using Newtonsoft.Json;
using UnityEngine;

public class CardsJsonCreator
{
    public enum CardActionType
    {
        activate,
        sell,
        choose,
        _throw
    }
    
    private static string CreateCardJson(CardActionType cardActionType, string cardId)
    {
        var authAttributes = new CardActionAttributes()
        {
            cardId = cardId,
        };
        var jsonString = JsonConvert.SerializeObject(authAttributes);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(cardActionType.ToString(), jsonString));
    }

    public static string CreateActivateCardJson(string cardId)
    {
        return CreateCardJson(CardActionType.activate, cardId);
    }
    
    public static string CreateSellCardJson(string cardId)
    {
        return CreateCardJson(CardActionType.sell, cardId);
    }
    
    public static string CreateChooseCardJson(string cardId)
    {
        return CreateCardJson(CardActionType.choose, cardId);
    }
    
    public static string CreateThrowCardJson(string cardId)
    {
        return CreateCardJson(CardActionType._throw, cardId);
    }


    private class CardActionAttributes    {
        public string cardId { get; set; }
    }
}
