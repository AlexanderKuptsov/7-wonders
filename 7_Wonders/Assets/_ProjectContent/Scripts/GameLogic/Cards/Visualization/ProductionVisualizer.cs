using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


namespace WhiteTeam.GameLogic.Cards.Visualization
{
public class ProductionVisualizer : CardVisualizer<ProductionCard>
{
    [SerializeField] private UnityEngine.UI.Image backgroundProduction = null;
    public ProductionVisualizer(ProductionCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return  new Color32(192,192,192,255);
        }

        public override Sprite GetBackground()
        {
          backgroundProduction.sprite   = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/production_background.png");
            return backgroundProduction.sprite;
        }

        public override Sprite GetCurrentEffect()
        {
             var currencyItems = cardData.CurrentEffect.ActionInfo;
            // TODO
            throw new System.NotImplementedException();
        }

        public override Sprite GetEnGameEffect()
        {
            throw new System.NotImplementedException();
        }
       
}
}
