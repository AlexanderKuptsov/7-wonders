using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class ArtemisTempleVisualizer : CardWonderVisualizer<ArtemisTempleWonderCard>
    {
        public Sprite effect = null;

        public ArtemisTempleVisualizer(ArtemisTempleWonderCard data) : base(data)
        {
        }


        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>("Pictures/Artemis");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone");
        }

        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone");
        }

        public override Sprite GetCostThirdEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/wood_wood");
        }

        public override Sprite GetInitialBonus()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/papyrus");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            var effectTemple = cardData.SecondStepBuild.CardEffect.Coins;
            if (effectTemple == 3)
                effect = UnityEngine.Resources.Load<Sprite>("Effects/three_coins");
            if (effectTemple == 4)
                effect = UnityEngine.Resources.Load<Sprite>("Effects/four_coins");
            if (effectTemple == 9)
                effect = UnityEngine.Resources.Load<Sprite>("Effects/nine_coins");

            return effect;
        }
    }
}