using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;
using WhiteTeam.Network.ServerModules;

public class CardFromJsonBuilder : MonoBehaviour
{
    public CommonCardData BuildCard(string cardJsonInfo)
    {
        var card = JsonConvert.DeserializeObject<Root>(cardJsonInfo);
        var type = AssistanceFunctions.GetEnumByNameUsual<CommonCardData.CardType>(card.type);
        var costInformation = card.costInfo.Select(info => new Resource.CurrencyItem
        {
            Amount = Convert.ToInt32(info.price),
            Currency = AssistanceFunctions.GetEnumByName<Resource.CurrencyProducts>(info.currency)
        }).ToArray();
        var specs = ((JObject) JsonConvert.DeserializeObject(cardJsonInfo))["specAttributes"].Value<string>();
        switch (type)
        {
            case CommonCardData.CardType.GUILDS_OWNING:
                break;
            case CommonCardData.CardType.GUILDS_SCIENCE:
                break;
            case CommonCardData.CardType.GUILDS_STRATEGY:
                break;
            case CommonCardData.CardType.CIVILIAN:
                break;
            case CommonCardData.CardType.MILITARY:
                break;
            case CommonCardData.CardType.COMMERCIAL_BONUS:
                var victoryEffect = VictoryEffectJson.Deserialize(specs);
                var cardTypeOwnMoneyEffect = CardTypeOwnMoneyEffectJson.Deserialize(specs);
                return new CommercialBonusCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, cardTypeOwnMoneyEffect, victoryEffect);
                break;
            case CommonCardData.CardType.COMMERCIAL_MONEY:
                var moneyEffect = MoneyEffectJson.Deserialize(specs);
                return new CommercialMoneyCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, moneyEffect);
                break;
            case CommonCardData.CardType.COMMERCIAL_TRADE:
                var tradeEffect = TradeEffectJson.Deserialize(specs);
                return new CommercialTradeCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, tradeEffect);
                break;
            case CommonCardData.CardType.PRODUCTION:
                break;
            case CommonCardData.CardType.SCIENTIFIC:
                break;
        }

        return null;
    }
}

public class CostInfo
{
    public string currency { get; set; }
    public string price { get; set; }
}

public class Root
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string epoch { get; set; }
    public CostInfo[] costInfo { get; set; }
    public string requirementBuildCardId { get; set; }
    public string specializationType { get; set; }
    public SpecificAttributes specAttributes { get; set; }
}

public class SpecificAttributes
{
}

public class TradeEffectJson
{
    public string[] discountPlayerDirections { get; set; }
    public string[] discountResources { get; set; }
    public string discountCost { get; set; }

    public static TradeEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<TradeEffectJson>(json);
        return new TradeEffect(
            res.discountPlayerDirections.Select(AssistanceFunctions.GetEnumByName<PlayerDirection>).ToArray(),
            res.discountResources.Select(AssistanceFunctions.GetEnumByName<Resource.CurrencyProducts>).ToArray(),
            Convert.ToInt32(res.discountCost));
    }
}


public class MoneyEffectJson
{
    public string coins { get; set; }

    public static MoneyEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<MoneyEffectJson>(json);
        return new MoneyEffect(
            Convert.ToInt32(res.coins));
    }
}

public class VictoryEffectJson
{
    public string victoryPoints { get; set; }

    public static VictoryEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<VictoryEffectJson>(json);
        return new VictoryEffect(
            Convert.ToInt32(res.victoryPoints));
    }
}

public class CardTypeOwnMoneyEffectJson
{
    public string[] playerDirection;
    public string cardType;
    public string currentMoneyBonus;

    public static CardTypeOwnMoneyEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<CardTypeOwnMoneyEffectJson>(json);
        return new CardTypeOwnMoneyEffect(
            res.playerDirection.Select(AssistanceFunctions.GetEnumByName<PlayerDirection>).ToArray(),
            AssistanceFunctions.GetEnumByName<CommonCardData.CardType>(res.cardType),
            Convert.ToInt32(res.currentMoneyBonus));
    }
}