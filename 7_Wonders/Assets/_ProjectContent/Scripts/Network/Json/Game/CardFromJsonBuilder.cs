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
                var ownVictoryEffect = CardTypeOwnVictoryEffectJson.Deserialize(specs);
                return new GuildsOwningCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, ownVictoryEffect);
            case CommonCardData.CardType.GUILDS_SCIENCE:
                return new GuildsScienceCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, new SelectableScienceEffect());
            case CommonCardData.CardType.GUILDS_STRATEGY:
                var strategyEffect = StrategyEffectJson.Deserialize(specs);
                return new GuildsStrategyCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, strategyEffect);
            case CommonCardData.CardType.CIVILIAN:
                var victoryEffectCivilian = VictoryEffectJson.Deserialize(specs);
                return new CivilianCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, victoryEffectCivilian);
            case CommonCardData.CardType.MILITARY:
                var militaryEffect = MilitaryEffectJson.Deserialize(specs);
                return new MilitaryCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, militaryEffect);
            case CommonCardData.CardType.COMMERCIAL_BONUS:
                var victoryEffect = VictoryEffectJson.Deserialize(specs);
                var cardTypeOwnMoneyEffect = CardTypeOwnMoneyEffectJson.Deserialize(specs);
                return new CommercialBonusCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, cardTypeOwnMoneyEffect, victoryEffect);
            case CommonCardData.CardType.COMMERCIAL_MONEY:
                var moneyEffect = MoneyEffectJson.Deserialize(specs);
                return new CommercialMoneyCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, moneyEffect);
            case CommonCardData.CardType.COMMERCIAL_TRADE:
                var tradeEffect = TradeEffectJson.Deserialize(specs);
                return new CommercialTradeCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, tradeEffect);
            case CommonCardData.CardType.PRODUCTION:
                var productionEffect = ProductionEffectJson.Deserialize(specs);
                return new ProductionCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, productionEffect);
            case CommonCardData.CardType.SCIENTIFIC:
                var scienceEffect = ScienceEffectJson.Deserialize(specs);
                return new ScientificCard(card.id, card.name, type, Convert.ToInt32(card.epoch), costInformation,
                    card.requirementBuildCardId, scienceEffect);
        }

        return null;
    }
}

public class CurrentItemInfo
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
    public CurrentItemInfo[] costInfo { get; set; }
    public string requirementBuildCardId { get; set; }
    public string specializationType { get; set; }
    public SpecificAttributes specAttributes { get; set; }
}

public class SpecificAttributes
{
}

public class StrategyEffectJson
{
    public string[] playerDirection;
    public string currentVictoryBonus;

    public static StrategyEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<StrategyEffectJson>(json);
        return new StrategyEffect(
            res.playerDirection.Select(AssistanceFunctions.GetEnumByName<PlayerDirection>).ToArray(),
            Convert.ToInt32(res.currentVictoryBonus));
    }
}

public class SelectableScienceEffectJson
{
    public CurrentItemInfo[] actionInfo { get; set; }

    public static ProductionCardEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<ProductionEffectJson>(json);
        return new ProductionCardEffect(res.actionInfo.Select(info => new Resource.CurrencyItem
        {
            Amount = Convert.ToInt32(info.price),
            Currency = AssistanceFunctions.GetEnumByName<Resource.CurrencyProducts>(info.currency)
        }).ToArray());
    }
}

public class ProductionEffectJson
{
    public CurrentItemInfo[] actionInfo { get; set; }

    public static ProductionCardEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<ProductionEffectJson>(json);
        return new ProductionCardEffect(res.actionInfo.Select(info => new Resource.CurrencyItem
        {
            Amount = Convert.ToInt32(info.price),
            Currency = AssistanceFunctions.GetEnumByName<Resource.CurrencyProducts>(info.currency)
        }).ToArray());
    }
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

public class MilitaryEffectJson
{
    public string shields { get; set; }

    public static MilitaryEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<MilitaryEffectJson>(json);
        return new MilitaryEffect(
            Convert.ToInt32(res.shields));
    }
}

public class ScienceEffectJson
{
    public CurrentItemInfo scienceInfo { get; set; }

    public static ScienceEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<ScienceEffectJson>(json);
        return new ScienceEffect((new Resource.ScienceItem()
        {
            Amount = Convert.ToInt32(res.scienceInfo.price),
            Currency = AssistanceFunctions.GetEnumByName<Resource.Science>(res.scienceInfo.currency)
        }));
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

public class CardTypeOwnVictoryEffectJson
{
    public string[] playerDirection;
    public string cardType;
    public string currentMoneyBonus;

    public static CardTypeOwnVictoryEffect Deserialize(string json)
    {
        var res = JsonConvert.DeserializeObject<CardTypeOwnVictoryEffectJson>(json);
        return new CardTypeOwnVictoryEffect(
            res.playerDirection.Select(AssistanceFunctions.GetEnumByName<PlayerDirection>).ToArray(),
            AssistanceFunctions.GetEnumByName<CommonCardData.CardType>(res.cardType),
            Convert.ToInt32(res.currentMoneyBonus));
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