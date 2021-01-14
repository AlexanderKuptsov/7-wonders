using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class HalicarnassusMausoleumVisualizer : CardWonderVisualizer<HalicarnassusMausoleum>
    {
        public HalicarnassusMausoleumVisualizer(HalicarnassusMausoleum data) : base(data)
        {
        }


        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>("Pictures/Halicarnassus");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/brick_brick");
        }

        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/ore_ore_ore");
        }

        public override Sprite GetCostThirdEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/loom_loom");
        }

        public override Sprite GetInitialBonus()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/loom");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/chevron-down");
        }
    }
}