using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public abstract class CardVisualizer<TCardData> : IVisualizer
        where TCardData : CommonCardData
    {
        protected TCardData cardData;
        public Sprite Cost = null;

        public CardVisualizer(TCardData data)
        {
            cardData = data;
        }

        //public abstract string GetNameCard();

        public string GetNameCard()
        {
            return cardData.Name;
        }

        public abstract Color GetColor();


        public abstract Sprite GetBackground();
        public abstract Sprite GetCurrentEffect();
        public abstract Sprite GetEndGameEffect();

        public Sprite GetCost()
        {
            var cost = cardData.CostInfo;

            if (cost.Length == 1)
            {
                foreach (var costinfo in cost)
                {
                    // MONEY 1
                    if (costinfo.Currency == Resources.Resource.CurrencyProducts.MONEY && costinfo.Amount == 1)
                    {
                        Cost = UnityEngine.Resources.Load<Sprite>(
                            "Effects/one 1");
                    }

                    //WOOD 1
                    if (costinfo.Currency == Resources.Resource.CurrencyProducts.WOOD && costinfo.Amount == 1)
                    {
                        Cost = UnityEngine.Resources.Load<Sprite>(
                            "Effects/Wood");
                    }

                    //ORE 1
                    if (costinfo.Currency == Resources.Resource.CurrencyProducts.ORE && costinfo.Amount == 1)
                    {
                        Cost = UnityEngine.Resources.Load<Sprite>(
                            "Effects/Gold ore");
                    }

                    //CLAY 1
                    if (costinfo.Currency == Resources.Resource.CurrencyProducts.CLAY && costinfo.Amount == 1)
                    {
                        Cost = UnityEngine.Resources.Load<Sprite>(
                            "Effects/brick");
                    }

                    // STONE 1
                    if (costinfo.Currency == Resources.Resource.CurrencyProducts.STONE && costinfo.Amount == 1)
                    {
                        Cost = UnityEngine.Resources.Load<Sprite>(
                            "Effects/stone");
                    }

                    // STONE 3
                    if (costinfo.Currency == Resources.Resource.CurrencyProducts.STONE && costinfo.Amount == 3)
                    {
                        Cost = UnityEngine.Resources.Load<Sprite>(
                            "Effects/stone_stone_stone");
                    }

                    // CLOTH 1
                    if (costinfo.Currency == Resources.Resource.CurrencyProducts.CLOTH && costinfo.Amount == 1)
                    {
                        Cost = UnityEngine.Resources.Load<Sprite>(
                            "Effects/loom");
                    }

                    //GLASS 1
                    if (costinfo.Currency == Resources.Resource.CurrencyProducts.GLASS && costinfo.Amount == 1)
                    {
                        Cost = UnityEngine.Resources.Load<Sprite>(
                            "Effects/glass");
                    }

                    //PAPYRUS
                    if (costinfo.Currency == Resources.Resource.CurrencyProducts.PAPYRUS && costinfo.Amount == 1)
                    {
                        Cost = UnityEngine.Resources.Load<Sprite>(
                            "Effects/papyrus");
                    }
                }
            }

            if (cost.Length == 2)
            {
                for (int i = 0; i < cost.Length; i++)
                {
                    //WOOD 1 ORE 2
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i + 1].Amount == 2)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/wood_ore_ore");
                        }
                    }

                    //WOOD 1 PAPYRUS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.PAPYRUS &&
                            cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/wood_ore_ore");
                        }
                    }

                    // WOOD 1 CLAY 2
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i + 1].Amount == 2)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/wood_papyrus");
                        }
                    }

                    // WOOD 1 CLAY 3

                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i + 1].Amount == 3)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/wood_brick_brick_brick");
                        }
                    }

                    // WOOD 2 ORE 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 2)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/wood_wood_ore");
                        }
                    }

                    //STONE 1 ORE 3
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 1)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i + 1].Amount == 3)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/stone_ore_ore_ore");
                        }
                    }

                    //STONE 2 LOOM 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 2)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.CLOTH &&
                            cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/stone_stone_loom");
                        }
                    }

                    //STONE 3 GLASS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 3)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.GLASS &&
                            cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/stone_stone_stone_glass");
                        }
                    }

                    //STONE 3 ORE 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 3)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/stone_stone_stone_ore");
                        }
                    }

                    //CLAY 2 LOOM 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 2)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.CLOTH &&
                            cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/brick_brick_loom");
                        }
                    }

                    //CLAY 2 PAPYRUS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 2)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.PAPYRUS &&
                            cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/clay_clay_papyrus");
                        }
                    }

                    //CLAY 3 GLASS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 3)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.GLASS &&
                            cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/brick_brick_brick_glass");
                        }
                    }

                    // ORE 2 GLASS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 2)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.GLASS &&
                            cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/ore_ore_glass 1");
                        }
                    }

                    //ORE 2 STONE 2
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 2)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.STONE &&
                            cost[i + 1].Amount == 2)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/ore_ore_stone_stone");
                        }
                    }

                    //GLASS 1 STONE 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.GLASS && cost[i].Amount == 1)
                    {
                        if (cost[i + 1].Currency == Resources.Resource.CurrencyProducts.STONE &&
                            cost[i + 1].Amount == 1)
                        {
                            Cost = UnityEngine.Resources.Load<Sprite>(
                                "Effects/glass_stone");
                        }
                    }
                }
            }

            if (cost.Length == 3)
            {
                for (int i = 0; i < cost.Length; i++)
                {
                    //WOOD 1 CLAY 1 GLASS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.GLASS && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/wood_brick_glass");
                            }
                        }
                    }

                    //WOOD 1 PAPYRUS 1 LOOM 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.PAPYRUS && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/wood_papyrus_loom");
                            }
                        }
                    }

                    //WOOD 2 PAPYRUS 1 GLASS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 2)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.PAPYRUS && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.GLASS && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/wood_wood_papyrus_glass");
                            }
                        }
                    }

                    //WOOD 2 ORE 2 PAPYRUS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 2)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 2)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.PAPYRUS && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/wood_wood_ore_ore_papyrus");
                            }
                        }
                    }

                    //WOOD 3 STONE 1 LOOM 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 3)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/wood_wood_wood_stone_loom");
                            }
                        }
                    }

                    //GLASS 1 ORE 1 STONE 2
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.GLASS && cost[i].Amount == 1)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 2)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/glass_ore_stone_stone");
                            }
                        }
                    }

                    //ORE 1 STONE 1 WOOD 2
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 1)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 2)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/ore_stone_wood_wood");
                            }
                        }
                    }

                    //ORE 1 CLAY 1 WOOD 1 
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 1)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/ore_brick_wood");
                            }
                        }
                    }

                    //ORE 1 WOOD 2 LOOM 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 1)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 2)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/ore_wood_wood_loom");
                            }
                        }
                    }

                    //ORE 2 GLASS 1 LOOM 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 2)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.GLASS && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/ore_ore_glass_loom");
                            }
                        }
                    }

                    //ORE 2 STONE 1 LOOM 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 2)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/ore_ore_stone_loom");
                            }
                        }
                    }

                    // CLAY 2 LOOM 1 PAPYRUS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 2)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.PAPYRUS && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/brick_brick_loom_papyrus");
                            }
                        }
                    }

                    //CLAY 3 LOOM 1 PAPYRUS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 3)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.PAPYRUS && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/brick_brick_brick_loom_papyrus");
                            }
                        }
                    }

                    //LOOM 1 ORE 1 WOOD 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i].Amount == 1)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/loom_ore_wood");
                            }
                        }
                    }

                    //LOOM 1 PAPYRUS 1 GLASS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i].Amount == 1)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.PAPYRUS && cost[i].Amount == 1)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.GLASS && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/loom_papyrus_glass");
                            }
                        }
                    }

                    //STONE 2 CLAY 2 GLASS 1
                    if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 2)
                    {
                        i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 2)
                        {
                            i++;
                            if (cost[i].Currency == Resources.Resource.CurrencyProducts.GLASS && cost[i].Amount == 1)
                            {
                                Cost = UnityEngine.Resources.Load<Sprite>(
                                    "Effects/stone_stone_clay_clay_glass");
                            }
                        }
                    }
                }
            }

            //ORE 2 CLAY 1 STONE 1 WOOD 1
            if (cost.Length == 4)
            {
                Cost = UnityEngine.Resources.Load<Sprite>(
                    "Effects/ore_ore_brick_stone_wood");
            }

            //CLAY 2 ORE 1 PAPYRUS 1 LOOM 1 GLASS 1
            if (cost.Length == 5)
            {
                Cost = UnityEngine.Resources.Load<Sprite>(
                    "Effects/brick_brick_loom_glass_ore_papyrus");
            }

            //GLASS 1 PAPYRUS 1 LOOM 1 WOOD 1 ORE 1 STONE 1
            if (cost.Length == 7)
            {
                Cost = UnityEngine.Resources.Load<Sprite>(
                    "Effects/glass_papyrus_loom_brick_wood_ore_stone");
            }

            return Cost;
        }
    }
}