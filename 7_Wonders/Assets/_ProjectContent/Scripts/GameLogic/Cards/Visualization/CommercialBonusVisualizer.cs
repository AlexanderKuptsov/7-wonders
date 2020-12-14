using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CommercialBonusVisualizer : CardVisualizer<CommercialBonusCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundCommercial = null;
       
        public CommercialBonusVisualizer(CommercialBonusCard data) : base(data)
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
            var cardType = cardData.CurrentEffect.CardType;
            var currentMoneyBonus = cardData.CurrentEffect.CurrentMoneyBonus;
            var playerdirections = cardData.CurrentEffect.PlayerDirection;
            throw new System.NotImplementedException();
        }

        public override Sprite GetEnGameEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}