using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CommercialTradeVisualizer : CardVisualizer<CommercialTradeCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundCommercial = null;
       
        public CommercialTradeVisualizer(CommercialTradeCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return new Color32(255,255,0, 255);
        }

        public override Sprite GetBackground()
        {
            
          backgroundCommercial.sprite = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/background_commercial.png");
            return backgroundCommercial.sprite;
        }

        public override Sprite GetCurrentEffect()
        {
            var currencyProducts = cardData.CurrentEffect.DiscountResources;
            var discountCost = cardData.CurrentEffect.DiscountCost;
            var playerdirections = cardData.CurrentEffect.DiscountPlayerDirections;
            throw new System.NotImplementedException();
        }

        public override Sprite GetEnGameEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}