using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CommercialTradeVisualizer : CardVisualizer<CommercialTradeCard>
    {
 
       public Sprite effectCommercialBonus =  null;
        public CommercialTradeVisualizer(CommercialTradeCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return new Color32(255,255,0, 255);
        }

        public override Sprite GetBackground()
        {

            return  UnityEngine.Resources.Load<Sprite> ("Pictures/background_commercial.png");
        }

        public override Sprite GetCurrentEffect()
        {
            var currencyProducts = cardData.CurrentEffect.DiscountResources;
            
            var discountCost = cardData.CurrentEffect.DiscountCost;
            var playerdirections = cardData.CurrentEffect.DiscountPlayerDirections;

           if (playerdirections.Length == 1)
           {
            foreach (var directions in playerdirections)
            {
                if (directions == PlayerDirection.LEFT)
                {
                    effectCommercialBonus = UnityEngine.Resources.Load<Sprite> ("Effects/left_arrow_coin_clay_stone_ore_wood.png");
                }
                if (directions == PlayerDirection.RIGHT)
                {
                    effectCommercialBonus = UnityEngine.Resources.Load<Sprite> ("Effects/one_clay_stone_ore_wood_right_arrow.png"); 
                }
            }
           }
           if (playerdirections.Length == 2)
            {
             effectCommercialBonus = UnityEngine.Resources.Load<Sprite> ("Effects/left_one_loom_glass_papyrus_right.png");   
            }
        
          //LOOM 1/ GLASS 1/ PAPYRUS 1
         if (currencyProducts.Length == 3)
         {
             effectCommercialBonus = UnityEngine.Resources.Load<Sprite>("Effects/loom_glass_papyrus.png");
         }
         //CLAY 1 / STONE 1 / ORE 1 / WOOD 1
         if (currencyProducts.Length == 4)
         {
             effectCommercialBonus = UnityEngine.Resources.Load<Sprite>("Effects/clay_stone_ore_wood.png");
         }
          
            return effectCommercialBonus;
        }

        public override Sprite GetEndGameEffect()
        {
           // cardData.EndGameEffect.DiscountPlayerDirections
            throw new System.NotImplementedException();
        }
      
    }
}