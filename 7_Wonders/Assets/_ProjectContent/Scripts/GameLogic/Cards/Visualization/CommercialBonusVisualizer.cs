using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CommercialBonusVisualizer : CardVisualizer<CommercialBonusCard>
    {
        public Sprite effectCommercialBonus = null;

        public CommercialBonusVisualizer(CommercialBonusCard data) : base(data)
        {
        }

        public override Color GetColor()
        {
            return new Color32(255, 255, 0, 255);
        }

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>("Pictures/background_commercial");
        }

        public override Sprite GetCurrentEffect()
        {
            var cardType = cardData.CurrentEffect.CardType;
            var currentMoneyBonus = cardData.CurrentEffect.CurrentMoneyBonus;
            var playerdirections = cardData.CurrentEffect.PlayerDirection;

            //PRODUCTION LEFT RIGHT SELF ONE
            if (cardType == CommonCardData.CardType.PRODUCTION && playerdirections.Length == 3 &&
                currentMoneyBonus == 1)
            {
                effectCommercialBonus = UnityEngine.Resources.Load<Sprite>("Effects/brown_card_arrows_one");
            }

            //PRODUCTION LEFT RIGHT SELF TWO
            if (cardType == CommonCardData.CardType.PRODUCTION && playerdirections.Length == 3 &&
                currentMoneyBonus == 2)
            {
                effectCommercialBonus = UnityEngine.Resources.Load<Sprite>("Effects/grey_card_arrows_two");
            }

            //PRODUCTION TWO POINTS
            if (cardType == CommonCardData.CardType.PRODUCTION && currentMoneyBonus == 2)
            {
                effectCommercialBonus = UnityEngine.Resources.Load<Sprite>("Effects/grey_card_two_two");
            }

            //PRODUCTION ONE POINT
            if (cardType == CommonCardData.CardType.PRODUCTION && currentMoneyBonus == 2)
            {
                effectCommercialBonus = UnityEngine.Resources.Load<Sprite>("Effects/brown_card_one_one");
            }

            //CommonCardData.CardType.COMMERCIAL_BONUS;
            return effectCommercialBonus;
        }

        public override Sprite GetEndGameEffect()
        {
            //  cardData.EndGameEffect.VictoryPoints
            throw new System.NotImplementedException();
        }
    }
}