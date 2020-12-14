using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


namespace WhiteTeam.GameLogic.Cards.Visualization
{
public class MilitaryVisualizer : CardVisualizer<MilitaryCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundMilitary = null;
       
        public MilitaryVisualizer(MilitaryCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return  new Color32(255,0,0,255);
        }

        public override Sprite GetBackground()
        {
            
          backgroundMilitary.sprite   = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/military_symbol.png");
            return backgroundMilitary.sprite;
        }

        public override  Sprite GetCurrentEffect()
        {
             var shield = cardData.CurrentEffect.Shields;
            throw new System.NotImplementedException();
        }

        public override Sprite GetEnGameEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}
