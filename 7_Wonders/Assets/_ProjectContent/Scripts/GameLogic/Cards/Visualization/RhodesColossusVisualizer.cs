using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class RhodesColossusVisualizer : CardWonderVisualizer<CollossWonderCard>
    {
        public Sprite effectColossus = null;

        public RhodesColossusVisualizer(CollossWonderCard data) : base(data)
        {
        }


        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>("Pictures/loginbackground");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone_stone");
        }

        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/clay_clay_papyrus");
        }

        public override Sprite GetCostThirdEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/ore_ore_ore_ore");
        }

        public override Sprite GetInitialBonus()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/Gold ore");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            var shields = cardData.SecondStepBuild.CardEffect.Shields;
            if (shields == 1)
                effectColossus = UnityEngine.Resources.Load<Sprite>("Effects/shield");
            if (shields == 2)
                effectColossus = UnityEngine.Resources.Load<Sprite>("Effects/shield_shield");
            if (shields == 3)
                effectColossus = UnityEngine.Resources.Load<Sprite>("Effects/shield_shield_shield");

            return effectColossus;
        }
    }
}