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
            return UnityEngine.Resources.Load<Sprite>("Pictures/Giza");
        }

        public override Sprite GetCostFirstEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone");
        }

        public override Sprite GetCostSecondEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/wood_wood_wood");
        }

        public override Sprite GetCostThirdEra()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone_stone_stone_stone");
        }

        //STONE
        public override Sprite GetInitialBonus()
        {
            return UnityEngine.Resources.Load<Sprite>("Effects/stone");
        }

        public override Sprite GetCurrentEffectStepTwo()
        {
            var effect = cardData.SecondStepBuild.CardEffect.VictoryPoints;
            if (effect == 3)
                effectPyramid = UnityEngine.Resources.Load<Sprite>("Effects/Number three");
            if (effect == 5)
                effectPyramid = UnityEngine.Resources.Load<Sprite>("Effects/Number five");
            if (effect == 7)
                effectPyramid = UnityEngine.Resources.Load<Sprite>("Effects/Number seven");

            return effectPyramid;
        }
    }
}