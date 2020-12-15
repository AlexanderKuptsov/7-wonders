using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CommercialMoneyVisualizer : CardVisualizer<CommercialMoneyCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundCommercial = null;
       
        public CommercialMoneyVisualizer(CommercialMoneyCard data) : base(data)
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
            var coins = cardData.CurrentEffect.Coins;  
            throw new System.NotImplementedException();
        }

        public override Sprite GetEndGameEffect()
        {
            throw new System.NotImplementedException();
        }

        public override string GetNameCard()
        {
            throw new System.NotImplementedException();
        }

        public override Sprite GetCost()
        {
            throw new System.NotImplementedException();
        }
    }
}