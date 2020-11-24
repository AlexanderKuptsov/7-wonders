using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Network.Json;
using Newtonsoft.Json;
using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

public class GameJsonReceiver : JsonReceiverBase<GameJsonResult, GameJsonReceiver>
{
}

public class GameJsonResult : Result
{
    public GameResult results { get; set; }
}

public class GameResult
{
    public InitInfo initInfo;
    public StartInfo startInfo;
    public CardUse cardUse;
    public WonderUse wonderUse;
    public TurnEnd turnEnd;
    public NewEpoch newEpoch;
}

public class InitInfo
{
    public CardInfo[] cards;
    public WonderCard[] wonderCards;
    public string[] playersPosition;
    public string lobbyId;
    public string gameId;
}

public class StartInfo
{
    public string wonder_id;
    public string[] startCards;
}

public class CardInfo
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string epoch { get; set; }
    public string[] costInfo { get; set; }
    public string requirementBuildCardId { get; set; }
    
}

public class WonderCard
{
}





public class CardUse
{
    public string id;
    public string action; // activate / sell / throw / swapRes
}

public class WonderUse
{
    
}

public class TurnEnd
{
    public string playerId;
}

public class NewEpoch
{
    public string epochNumber;
}