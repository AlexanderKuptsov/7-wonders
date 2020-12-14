using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
public class CivilianVisualizer :CardVisualizer<CivilianCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundCivilian = null;
       
        public CivilianVisualizer(CivilianCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return  new Color32(0,191,255,255);
        }

        public override Sprite GetBackground()
        {
          backgroundCivilian.sprite   = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/military_symbol.png");
            return backgroundCivilian.sprite;
        }

        public override Sprite GetCurrentEffect()
        {
            // TODO
             var victoryPoints = cardData.CurrentEffect.VictoryPoints;
            throw new System.NotImplementedException();
        }

        public override Sprite GetEnGameEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}
