using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class ScientificVisualizer : CardVisualizer<ScientificCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundScientific = null;
       
        public ScientificVisualizer(ScientificCard data) : base(data)
        {

        }
        public override Color GetColor()
        {
            return new Color32(46,139,87, 255);
        }

        public override Sprite GetBackground()
        {
            
          backgroundScientific.sprite   = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/scientific_background.png");
            return backgroundScientific.sprite;
        }

        public override Sprite GetCurrentEffect()
        {
            
            var scienceinfo = cardData.CurrentEffect.ScienceInfo;
            throw new System.NotImplementedException();
        }

        public override Sprite GetEnGameEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}