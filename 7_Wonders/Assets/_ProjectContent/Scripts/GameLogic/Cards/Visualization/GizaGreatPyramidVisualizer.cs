using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class GizaGreatPyramidVisualizer : CardWonderVisualizer<GizaGreatPyramidWonderCard>
    {
        
        public Sprite effectPyramid = null;
         public GizaGreatPyramidVisualizer(GizaGreatPyramidWonderCard data) : base(data)
         {
          
         }
       

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite> ("Pictures/Giza.png");
        }

       public override Sprite GetCostFirstEra()
        {
           return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone.png");
        }
        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/wood_wood_wood.png");
        }
        public override Sprite GetCostThirdEra()
        {
            
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone_stone_stone.png");
        }
        //STONE
        public override Sprite GetInitialBonus()
        {
            return UnityEngine.Resources.Load<Sprite> ("Effects/stone.png");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            var effect = cardData.SecondStepBuild.CardEffect.VictoryPoints;
            if ( effect == 3)
                effectPyramid = UnityEngine.Resources.Load<Sprite> ("Effects/Number three.png");
            if (effect == 5)
                effectPyramid = UnityEngine.Resources.Load<Sprite> ("Effects/Number five.png");
            if (effect == 7)
                effectPyramid = UnityEngine.Resources.Load<Sprite> ("Effects/Number seven.png");

            return effectPyramid;
        }
    }
}