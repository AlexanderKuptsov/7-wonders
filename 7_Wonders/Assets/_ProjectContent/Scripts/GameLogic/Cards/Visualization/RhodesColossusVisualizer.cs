using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class RhodesColossusVisualizer : CardWonderVisualizer<CollossWonderCard>
    {

         public Sprite effectColossus = null;
         public RhodesColossusVisualizer (CollossWonderCard data) : base(data)
         {
          
         }
       

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite> ("Pictures/loginbackground.jpg");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone_stone.png");
        }
        public override Sprite GetCostSecondEra()
        {
            
          return UnityEngine.Resources.Load<Sprite>("Effects/ore_ore_ore_ore.png");
        }
        public override Sprite GetCostThirdEra()
        {
            
            return null;
        }
        public override Sprite GetInitialBonus()
        {   
            return UnityEngine.Resources.Load<Sprite>("Effects/Gold ore.png");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
        
          var shields =  cardData.SecondStepBuild.CardEffect.Shields;
            if (shields == 1)
                effectColossus =  UnityEngine.Resources.Load<Sprite>("Effects/shield.png");
            if (shields == 2)
                effectColossus =  UnityEngine.Resources.Load<Sprite>("Effects/shield_shield.png");
            if (shields == 3)
                effectColossus =  UnityEngine.Resources.Load<Sprite>("Effects/shield_shield_shield.png");
             
            return effectColossus;
        }
    }
}