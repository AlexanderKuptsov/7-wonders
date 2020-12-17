using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


namespace WhiteTeam.GameLogic.Cards.Visualization
{
public class ProductionVisualizer : CardVisualizer<ProductionCard>
{
    [SerializeField] private Sprite backgroundProduction = null;
    [SerializeField] private Sprite effectProduction = null;
    [SerializeField] private string CardName = null;
    [SerializeField] private Sprite Cost = null;

    public ProductionVisualizer(ProductionCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return  new Color32(192,192,192,255);
        }

        public override Sprite GetBackground()
        {
          backgroundProduction  = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/production_background.png");
            return backgroundProduction;
        }

        public override Sprite GetCurrentEffect()
        {
             var currencyItems = cardData.CurrentEffect.ActionInfo;

             foreach(var action in currencyItems)
             {
                  //LOOM 1
                if(action.Currency == Resources.Resource.CurrencyProducts.CLOTH && action.Amount == 1)
                {
                    effectProduction = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/loom.png");
                    SetNameCard("Loom");
                    SetCost(null);
                }
                //GLASSWORKS 1
                if(action.Currency == Resources.Resource.CurrencyProducts.GLASS && action.Amount == 1)
                {
                    effectProduction = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/glass.png");
                    SetNameCard("GlassWorks");
                    SetCost(null);
                }
                //PAPYRUS 1
                if(action.Currency == Resources.Resource.CurrencyProducts.PAPYRUS && action.Amount == 1)
                {
                    effectProduction = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/papyrus.png");
                    SetNameCard("Press");
                    SetCost(null);
               }
             }
            // TODO
            return effectProduction;
        }

        public override Sprite GetEndGameEffect()
        {
            throw new System.NotImplementedException();
        }
        public override string GetNameCard()
        {
            return CardName;
        }
        public override Sprite GetCost()
        {
           return Cost;
        }
           public void SetNameCard(string name)
        {
            this.CardName = name;
        }
          public void SetCost(Sprite costeffect)
        {
            this.Cost = costeffect;
        }

       
}
}
