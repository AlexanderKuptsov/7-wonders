using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


namespace WhiteTeam.GameLogic.Cards.Visualization
{
public class ProductionVisualizer : CardVisualizer<ProductionCard>
{

    public Sprite effectProduction = null;

   

    public ProductionVisualizer(ProductionCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return  new Color32(192,192,192,255);
        }

        public override Sprite GetBackground()
        {
         
            return UnityEngine.Resources.Load<Sprite> ("Pictures/production_background.png");
        }

        public override Sprite GetCurrentEffect()
        {
             var currencyItems = cardData.CurrentEffect.ActionInfo;

             foreach(var action in currencyItems)
             {
                  //LOOM 1
                if(action.Currency == Resources.Resource.CurrencyProducts.CLOTH && action.Amount == 1)
                {
                    effectProduction = UnityEngine.Resources.Load<Sprite>("Effects/loom.png");
                   
                }
                //GLASSWORKS 1
                if(action.Currency == Resources.Resource.CurrencyProducts.GLASS && action.Amount == 1)
                {
                    effectProduction = UnityEngine.Resources.Load<Sprite>("Effects/glass.png");
                    
                }
                //PAPYRUS 1
                if(action.Currency == Resources.Resource.CurrencyProducts.PAPYRUS && action.Amount == 1)
                {
                    effectProduction = UnityEngine.Resources.Load<Sprite>("Effects/papyrus.png");
                  
               }
             }
            // TODO
            return effectProduction;
        }

        public override Sprite GetEndGameEffect()
        {
            return null;
        }
       

       
}
}
