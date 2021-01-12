using Microsoft.Unity.VisualStudio.Editor;
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
            return UnityEngine.Resources.Load<Sprite>("Pictures/Hanging Gardens.png");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/brick_brick.png");
        }
        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/wood_wood_wood.png");
        }
        public override Sprite GetCostThirdEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/brick_brick_brick_brick.png");
        }
        public override Sprite GetInitialBonus()

        {
            return UnityEngine.Resources.Load<Sprite>("Effects/brick.png");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/square_compass_cog_stone 1.png");
        }
    }
}