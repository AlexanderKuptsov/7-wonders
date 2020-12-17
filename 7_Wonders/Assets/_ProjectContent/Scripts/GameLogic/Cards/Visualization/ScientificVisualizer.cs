using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class ScientificVisualizer : CardVisualizer<ScientificCard>
    {
        public Sprite ScienceEffect = null;


        public ScientificVisualizer(ScientificCard data) : base(data)
        {
        }

        public override Color GetColor()
        {
            return new Color32(46, 139, 87, 255);
        }

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>("Pictures/scientific_background");
        }

        public override Sprite GetCurrentEffect()
        {
            var scienceinfo = cardData.CurrentEffect.ScienceInfo;
            if (scienceinfo.Currency == Resources.Resource.Science.RUNE_1 && scienceinfo.Amount == 1)
                ScienceEffect = UnityEngine.Resources.Load<Sprite>("Effects/square_compass_");
            if (scienceinfo.Currency == Resources.Resource.Science.RUNE_2 && scienceinfo.Amount == 1)
                ScienceEffect = UnityEngine.Resources.Load<Sprite>("Effects/cog_");
            if (scienceinfo.Currency == Resources.Resource.Science.RUNE_3 && scienceinfo.Amount == 1)
                ScienceEffect = UnityEngine.Resources.Load<Sprite>("Effects/stone 1");


            return ScienceEffect;
        }

        public override Sprite GetEndGameEffect()
        {
            return null;
        }
    }
}