using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
public class CivilianVisualizer :CardVisualizer<CivilianCard>
    {
     
        public Sprite effectCivilian = null;



       
        public CivilianVisualizer(CivilianCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return  new Color32(0,191,255,255);
        }

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/military_symbol.png");
        }

        public override Sprite GetCurrentEffect()
        {
            // TODO
             var victoryPoints = cardData.CurrentEffect.VictoryPoints;

             switch(victoryPoints)
             {
                 case 2:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number two.png");
                       break;
                case 3:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number three.png");
                       break;
                case 5:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number five.png");
                       break;
                case 6:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number six.png");
                       break;
                case 7:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number seven.png");
                       break;
                case 8:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number eight.png");
                       break;
                default:
                      effectCivilian = null;
                       break;
              
             }
            return effectCivilian;
        }

        public override Sprite GetEndGameEffect()
        {
           return null;
        }

        

        
        
        
    }
}
