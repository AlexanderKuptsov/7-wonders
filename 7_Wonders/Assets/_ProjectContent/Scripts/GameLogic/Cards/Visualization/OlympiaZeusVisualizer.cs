using Microsoft.Unity.VisualStudio.Editor;
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
            return UnityEngine.Resources.Load<Sprite> ("Pictures/Zeus statue.jpg");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/wood_wood.png");
        }
        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone.png");
        }
        public override Sprite GetCostThirdEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/cloth_ore_ore.png");
        }
        public override Sprite GetInitialBonus()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/Wood.png");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            
            return UnityEngine.Resources.Load<Sprite>("Effects/Number five.png");
        }
    }
}