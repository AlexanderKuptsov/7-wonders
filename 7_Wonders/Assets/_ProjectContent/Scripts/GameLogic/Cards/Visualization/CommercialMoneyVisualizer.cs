using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CommercialMoneyVisualizer : CardVisualizer<CommercialMoneyCard>
    {
        public Sprite effectCommercialMoney = null;

        public CommercialMoneyVisualizer(CommercialMoneyCard data) : base(data)
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
            var coins = cardData.CurrentEffect.Coins;
            if (coins == 5)
                effectCommercialMoney = UnityEngine.Resources.Load<Sprite>("Effects/coin_five");


            return effectCommercialMoney;
        }

        public override Sprite GetEndGameEffect()
        {
            // return cardData.EndGameEffect.Coins 
            throw new System.NotImplementedException();
        }
    }
}