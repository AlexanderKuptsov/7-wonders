using System.Collections;
using System.Collections.Generic;
using Network.Json;
using Newtonsoft.Json;
using UnityEngine;
using WhiteTeam.GameLogic.Actions;

public static class CardsJsonCreator
{
    
    public static string CreateCardJson(string gameId, string cardId, string command)
    {
        var authAttributes = new CardActionAttributes()
        {
            gameId = gameId,
            cardId = cardId
        };
        var jsonString = JsonConvert.SerializeObject(authAttributes);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(command, jsonString));
    }

    
    private class CardActionAttributes    {
        public string cardId { get; set; }
        public string gameId { get; set; }
    }
}
