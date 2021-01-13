using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class HangingGardensVisualizer : CardWonderVisualizer<HangingGardensWonderCard>
    {
        public HangingGardensVisualizer(HangingGardensWonderCard data) : base(data)
        {
        }


        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>("Pictures/Hanging Gardens");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/brick_brick");
        }

        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/wood_wood_wood");
        }

        public override Sprite GetCostThirdEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/brick_brick_brick_brick");
        }

        public override Sprite GetInitialBonus()

        {
            return UnityEngine.Resources.Load<Sprite>("Effects/brick");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/square_compass_cog_stone 1");
        }
    }
}