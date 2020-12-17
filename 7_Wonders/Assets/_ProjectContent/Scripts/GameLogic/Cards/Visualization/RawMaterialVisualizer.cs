using Microsoft.Unity.VisualStudio.Editor;

using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{ 
    public class RawMaterialVisualizer : CardVisualizer<RawMaterialsCard>
    {
        private Sprite backgroundRawMaterials = null;
        
        private Sprite effectRawMaterials = null;

        private string CardName = null;

        private Sprite Cost = null;

       
        public RawMaterialVisualizer(RawMaterialsCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return new Color32(139, 69, 19, 255);
        }

        public override Sprite GetBackground()
        {
            
          backgroundRawMaterials = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/raw_material_symbol.png");
            return backgroundRawMaterials;
        }

        public override Sprite GetCurrentEffect()
        {
            
            var currencyItems = cardData.CurrentEffect.ActionInfo;
            
            if (currencyItems.Length == 1)
            {
               foreach(var action in currencyItems)
            {
                    //WOOD 1
                if(action.Currency == Resources.Resource.CurrencyProducts.WOOD && action.Amount == 1)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Wood.png");
                    SetNameCard("Lumber Yard");
                    SetCost(null);
                }
                //WOOD 2
                if(action.Currency == Resources.Resource.CurrencyProducts.WOOD && action.Amount == 2)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_wood.png");
                    Debug.Log(effectRawMaterials);
                    SetNameCard("Sawmill");
                    SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
                }
                //STONE 1
                if(action.Currency == Resources.Resource.CurrencyProducts.STONE && action.Amount == 1)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone.png");
                    SetNameCard("Stone Pit");
                    SetCost(null);
               }
                //STONE 2
                if(action.Currency == Resources.Resource.CurrencyProducts.STONE && action.Amount == 2)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_stone.png");
                    SetNameCard("Quarry");
                    SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
                }
                //CLAY 1
                if(action.Currency == Resources.Resource.CurrencyProducts.CLAY && action.Amount == 1)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/brick.png");
                    SetNameCard("Clay Pool");
                    SetCost(null);
                }
                //CLAY 2
                if(action.Currency == Resources.Resource.CurrencyProducts.CLAY && action.Amount == 2)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/brick_brick.png");
                    SetNameCard("Brickyard");
                    SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
                }
                //ORE 1
                if(action.Currency == Resources.Resource.CurrencyProducts.ORE && action.Amount == 1)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Gold ore.png");
                    SetNameCard("Ore Vein");
                    SetCost(null);
                }
                //ORE 2
                if(action.Currency == Resources.Resource.CurrencyProducts.ORE && action.Amount == 2)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/ore_ore.png");
                    SetNameCard("Foundry");
                    SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
                }

              }
            }

            //SIZE = 2
            if(currencyItems.Length == 2) 
            {
                //WOOD 1 CLAY 1
               for(int i = 0; i < currencyItems.Length; i++)
               {     
                if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.WOOD && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.CLAY && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_brick.png");
                           SetNameCard("Tree Farm");
                           SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
                      }
                 }
                 //STONE 1 CLAY 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.STONE && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.CLAY && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_brick.png");
                           SetNameCard("Excavation");
                           SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
                      }
                 }
                 //CLAY 1 ORE 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.CLAY && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.ORE && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/brick_ore.png");
                            SetNameCard("Clay Pit");
                            SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
                      }
                 }
                 //STONE 1 WOOD 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.STONE && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.WOOD && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_wood.png");
                           SetNameCard("Timber Yard");
                           SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
                      }
                 }
                 //WOOD 1 ORE 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.WOOD && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.ORE && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_ore.png");
                           SetNameCard("Forest Cave");
                           SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
                      }
                 }
                 //ORE 1 STONE 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.ORE && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.STONE && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/ore_stone.png");
                           SetNameCard("Mine");
                           SetCost(UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/one 1.png"));
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
        
        public override string GetNameCard()
        {
            this.GetCurrentEffect();

             var name = cardData.Name;
            return CardName;
        }

        public void SetNameCard(string name)
        {
            this.CardName = name;
        }

          public void SetCost(Sprite costeffect)
        {
            this.Cost = costeffect;
        }

        public override Sprite GetCost()
        {
            /*KNOWING THAT 

            var costinfo = cardData.costinfo

            HAS SAME ATTRIBUTES (Currency, Amount) THAT currentEffects, I USE THE SAME TO RETURN COST EFFECT IMAGE
            */
            this.GetCurrentEffect();
            return Cost;
        }














        
        
    }
}