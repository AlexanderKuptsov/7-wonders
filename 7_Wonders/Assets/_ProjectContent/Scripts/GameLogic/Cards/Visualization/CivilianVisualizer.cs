using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CivilianVisualizer : CardVisualizer<CivilianCard>
    {
        public Sprite effectCivilian = null;


        public CivilianVisualizer(CivilianCard data) : base(data)
        {
        }

        public override Color GetColor()
        {
            return new Color32(0, 191, 255, 255);
        }

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>("Pictures/military_symbol");
        }

        public override Sprite GetCurrentEffect()
        {
            // TODO
            var victoryPoints = cardData.CurrentEffect.VictoryPoints;

            switch (victoryPoints)
            {
                case 2:
                    effectCivilian = UnityEngine.Resources.Load<Sprite>("Effects/Number two");
                    break;
                case 3:
                    effectCivilian = UnityEngine.Resources.Load<Sprite>("Effects/Number three");
                    break;
                case 5:
                    effectCivilian = UnityEngine.Resources.Load<Sprite>("Effects/Number five");
                    break;
                case 6:
                    effectCivilian = UnityEngine.Resources.Load<Sprite>("Effects/Number six");
                    break;
                case 7:
                    effectCivilian = UnityEngine.Resources.Load<Sprite>("Effects/Number seven");
                    break;
                case 8:
                    effectCivilian = UnityEngine.Resources.Load<Sprite>("Effects/Number eight");
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