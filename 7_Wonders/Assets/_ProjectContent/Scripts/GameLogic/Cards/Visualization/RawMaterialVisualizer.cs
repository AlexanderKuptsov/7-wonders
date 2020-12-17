using Microsoft.Unity.VisualStudio.Editor;

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
            return UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/raw_material_symbol.png");
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
                }
                //WOOD 2
                if(action.Currency == Resources.Resource.CurrencyProducts.WOOD && action.Amount == 2)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_wood.png");
                    
                }
                //STONE 1
                if(action.Currency == Resources.Resource.CurrencyProducts.STONE && action.Amount == 1)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone.png");
                
               }
                //STONE 2
                if(action.Currency == Resources.Resource.CurrencyProducts.STONE && action.Amount == 2)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_stone.png");
                }
                //CLAY 1
                if(action.Currency == Resources.Resource.CurrencyProducts.CLAY && action.Amount == 1)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/brick.png");
                
                }
                //CLAY 2
                if(action.Currency == Resources.Resource.CurrencyProducts.CLAY && action.Amount == 2)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/brick_brick.png");
                    
                }
                //ORE 1
                if(action.Currency == Resources.Resource.CurrencyProducts.ORE && action.Amount == 1)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Gold ore.png");
                 
                }
                //ORE 2
                if(action.Currency == Resources.Resource.CurrencyProducts.ORE && action.Amount == 2)
                {
                    effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/ore_ore.png");
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
                      }
                 }
                 //STONE 1 CLAY 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.STONE && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.CLAY && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_brick.png");
    
                      }
                 }
                 //CLAY 1 ORE 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.CLAY && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.ORE && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/brick_ore.png");
                        
                      }
                 }
                 //STONE 1 WOOD 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.STONE && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.WOOD && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_wood.png");
                          
                      }
                 }
                 //WOOD 1 ORE 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.WOOD && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.ORE && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_ore.png");
                          
                      }
                 }
                 //ORE 1 STONE 1
                 if(currencyItems[i].Currency== Resources.Resource.CurrencyProducts.ORE && currencyItems[i].Amount == 1 )
                 {
                      if(currencyItems[i+1].Currency == Resources.Resource.CurrencyProducts.STONE && currencyItems[i+1].Amount == 1)
                      {
                           effectRawMaterials = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/ore_stone.png");
                      }
                 }
              
             }
            }
            //SIZE CANNOT BE OVER 2 (I GUESS)

            return effectRawMaterials;
        }
        
        public override Sprite GetEndGameEffect()
        {
            throw null;
        }
        

      














        
        
    }
}