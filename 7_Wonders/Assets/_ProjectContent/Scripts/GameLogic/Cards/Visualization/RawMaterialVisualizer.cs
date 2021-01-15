using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class RawMaterialVisualizer : CardVisualizer<RawMaterialsCard>
    {
        public Sprite effectRawMaterials = null;


        public RawMaterialVisualizer(RawMaterialsCard data) : base(data)
        {
        }

        public override Color GetColor()
        {
            return new Color32(139, 69, 19, 255);
        }

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>(
                "Pictures/raw_material_symbol");
        }

        public override Sprite GetCurrentEffect()
        {
            var currencyItems = cardData.CurrentEffect.ActionInfo;


            if (currencyItems.Length == 1)
            {
                foreach (var action in currencyItems)
                {
                    //WOOD 1
                    if (action.Currency == Resources.Resource.CurrencyProducts.WOOD && action.Amount == 1)
                    {
                        effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Effects/Wood");
                    }

                    //WOOD 2
                    if (action.Currency == Resources.Resource.CurrencyProducts.WOOD && action.Amount == 2)
                    {
                        effectRawMaterials =
                            UnityEngine.Resources.Load<Sprite>("Effects/wood_wood");
                    }

                    //STONE 1
                    if (action.Currency == Resources.Resource.CurrencyProducts.STONE && action.Amount == 1)
                    {
                        effectRawMaterials =
                            UnityEngine.Resources.Load<Sprite>("Effects/stone");
                    }

                    //STONE 2
                    if (action.Currency == Resources.Resource.CurrencyProducts.STONE && action.Amount == 2)
                    {
                        effectRawMaterials =
                            UnityEngine.Resources.Load<Sprite>(
                                "Effects/stone_stone");
                    }

                    //CLAY 1
                    if (action.Currency == Resources.Resource.CurrencyProducts.CLAY && action.Amount == 1)
                    {
                        effectRawMaterials =
                            UnityEngine.Resources.Load<Sprite>("Effects/brick");
                    }

                    //CLAY 2
                    if (action.Currency == Resources.Resource.CurrencyProducts.CLAY && action.Amount == 2)
                    {
                        effectRawMaterials =
                            UnityEngine.Resources.Load<Sprite>(
                                "Effects/brick_brick");
                    }

                    //ORE 1
                    if (action.Currency == Resources.Resource.CurrencyProducts.ORE && action.Amount == 1)
                    {
                        effectRawMaterials =
                            UnityEngine.Resources.Load<Sprite>("Effects/Gold ore");
                    }

                    //ORE 2
                    if (action.Currency == Resources.Resource.CurrencyProducts.ORE && action.Amount == 2)
                    {
                        effectRawMaterials =
                            UnityEngine.Resources.Load<Sprite>("Effects/ore_ore");
                    }
                }
            }

            //SIZE = 2
            if (currencyItems.Length == 2)
            {
                //WOOD 1 CLAY 1
                for (int i = 0; i < currencyItems.Length; i++)
                {
                    if (currencyItems[i].Currency == Resources.Resource.CurrencyProducts.WOOD &&
                        currencyItems[i].Amount == 1)
                    {
                        if (currencyItems[i + 1].Currency == Resources.Resource.CurrencyProducts.CLAY &&
                            currencyItems[i + 1].Amount == 1)
                        {
                            effectRawMaterials =
                                UnityEngine.Resources.Load<Sprite>(
                                    "Effects/wood_brick");
                        }
                    }

                    //STONE 1 CLAY 1
                    if (currencyItems[i].Currency == Resources.Resource.CurrencyProducts.STONE &&
                        currencyItems[i].Amount == 1)
                    {
                        if (currencyItems[i + 1].Currency == Resources.Resource.CurrencyProducts.CLAY &&
                            currencyItems[i + 1].Amount == 1)
                        {
                            effectRawMaterials =
                                UnityEngine.Resources.Load<Sprite>(
                                    "Effects/stone_brick");
                        }
                    }

                    //CLAY 1 ORE 1
                    if (currencyItems[i].Currency == Resources.Resource.CurrencyProducts.CLAY &&
                        currencyItems[i].Amount == 1)
                    {
                        if (currencyItems[i + 1].Currency == Resources.Resource.CurrencyProducts.ORE &&
                            currencyItems[i + 1].Amount == 1)
                        {
                            effectRawMaterials =
                                UnityEngine.Resources.Load<Sprite>(
                                    "Effects/brick_ore");
                        }
                    }

                    //STONE 1 WOOD 1
                    if (currencyItems[i].Currency == Resources.Resource.CurrencyProducts.STONE &&
                        currencyItems[i].Amount == 1)
                    {
                        if (currencyItems[i + 1].Currency == Resources.Resource.CurrencyProducts.WOOD &&
                            currencyItems[i + 1].Amount == 1)
                        {
                            effectRawMaterials =
                                UnityEngine.Resources.Load<Sprite>(
                                    "Effects/stone_wood");
                        }
                    }

                    //WOOD 1 ORE 1
                    if (currencyItems[i].Currency == Resources.Resource.CurrencyProducts.WOOD &&
                        currencyItems[i].Amount == 1)
                    {
                        if (currencyItems[i + 1].Currency == Resources.Resource.CurrencyProducts.ORE &&
                            currencyItems[i + 1].Amount == 1)
                        {
                            effectRawMaterials =
                                UnityEngine.Resources.Load<Sprite>(
                                    "Effects/wood_ore");
                        }
                    }

                    //ORE 1 STONE 1
                    if (currencyItems[i].Currency == Resources.Resource.CurrencyProducts.ORE &&
                        currencyItems[i].Amount == 1)
                    {
                        if (currencyItems[i + 1].Currency == Resources.Resource.CurrencyProducts.STONE &&
                            currencyItems[i + 1].Amount == 1)
                        {
                            effectRawMaterials =
                                UnityEngine.Resources.Load<Sprite>(
                                    "Effects/ore_stone");
                        }
                    }
                }
            }
            //SIZE CANNOT BE OVER 2 (I GUESS)

            return effectRawMaterials;
        }

        public override Sprite GetEndGameEffect()
        {
            return null;
        }
    }
}