using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class AlexandriaLightHouseVisualizer : CardWonderVisualizer<AlexandriaLighthouseWonderCard>
    {

         public AlexandriaLightHouseVisualizer(AlexandriaLighthouseWonderCard data) : base(data)
         {
          
         }
       

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite> ("Pictures/Alexandria");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone");
        }
        public override Sprite GetCostSecondEra()
        {
           return UnityEngine.Resources.Load<Sprite>("Effects/ore_ore");
        }
        public override Sprite GetCostThirdEra()
        {
          return UnityEngine.Resources.Load<Sprite>("Effects/glass_glass");
        }
        public override Sprite GetInitialBonus()
        {
            return UnityEngine.Resources.Load<Sprite> ("Effects/glass");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            //cardData.SecondStepBuild.CardEffect.ActionInfo;
            return UnityEngine.Resources.Load<Sprite>("Effects/brick_wood_ore_stone");
        }
    }
}