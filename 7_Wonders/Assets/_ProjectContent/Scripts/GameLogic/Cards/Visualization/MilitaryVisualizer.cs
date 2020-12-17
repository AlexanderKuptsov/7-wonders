using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


namespace WhiteTeam.GameLogic.Cards.Visualization
{
public class MilitaryVisualizer : CardVisualizer<MilitaryCard>
    {
        
        public Sprite effectMilitary = null;

        public MilitaryVisualizer(MilitaryCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return  new Color32(255,0,0,255);
        }

        public override Sprite GetBackground()
        {
  
            return UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/military_symbol.png");
        }

        public override  Sprite GetCurrentEffect()
        {
             var shield = cardData.CurrentEffect.Shields;
                switch(shield)
                {
                    case 1 :
                        effectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/shield.png");
                        break;
                    case 2 :
                        effectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/shield_shield.png");
                        break;
                    case 3 :
                        effectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/shield_shield_shield.png");
                        break;
                    default:
                         effectMilitary = null;
                         break;
                }
             
            return effectMilitary;
        }

        public override Sprite GetEndGameEffect()
        {
           return null;
        }

}

}
