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
            return new Color32(46,139,87, 255);
        }

        public override Sprite GetBackground()
        {

            return UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/scientific_background.png");
        }

        public override Sprite GetCurrentEffect()
        {
            
            var scienceinfo = cardData.CurrentEffect.ScienceInfo;
               if (scienceinfo.Currency == Resources.Resource.Science.RUNE_1 && scienceinfo.Amount == 1)
                   ScienceEffect = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Effects/square_compass_.png");
               if (scienceinfo.Currency == Resources.Resource.Science.RUNE_2 && scienceinfo.Amount == 1)
                   ScienceEffect = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Effects/cog_.png");
               if (scienceinfo.Currency == Resources.Resource.Science.RUNE_3 && scienceinfo.Amount == 1)
                   ScienceEffect = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Effects/stone 1.png");
                   

            return ScienceEffect;
        }

        public override Sprite GetEndGameEffect()
        {
            return null;
        }
        
    }
}