using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class OlympiaZeusVisualizer : CardWonderVisualizer<OlympiaZeusStatueWonderCard>
    {
        public OlympiaZeusVisualizer(OlympiaZeusStatueWonderCard data) : base(data)
        {
        }


        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>("Pictures/Zeus statue");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/wood_wood");
        }

        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone");
        }

        public override Sprite GetCostThirdEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/cloth_ore_ore");
        }

        public override Sprite GetInitialBonus()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/Wood");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/Number five");
        }
    }
}