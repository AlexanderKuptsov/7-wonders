using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class  HalicarnassusMausoleumVisualizer : CardWonderVisualizer<HalicarnassusMausoleum>
    {

         public HalicarnassusMausoleumVisualizer(HalicarnassusMausoleum data) : base(data)
         {
          
         }
       

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite> ("Pictures/Halicarnassus.png");
        }

        public override Sprite GetCostFirstEra()
        {            
            return UnityEngine.Resources.Load<Sprite>("Effects/brick_brick.png");
        }
        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/ore_ore_ore.png");
        }
        public override Sprite GetCostThirdEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/loom_loom.png");
        }
        public override Sprite GetInitialBonus()
        {
            
            return UnityEngine.Resources.Load<Sprite>("Effects/loom.png");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            
            return null;
        }
    }
}