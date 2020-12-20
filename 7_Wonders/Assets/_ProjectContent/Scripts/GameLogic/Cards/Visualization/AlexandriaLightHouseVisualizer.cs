using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class AlexandriaLightHouseVisualizer : CardWonderVisualizer<AlexandriaLighthouseWonderCard>
    {

         public AlexandriaLightHouseVisualizer(AlexandriaLighthouseWonderCard data) : base(data)
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

        public override Sprite GetCostFirstEra()
        {
            return null;
        }
        public override Sprite GetCostSecondEra()
        {
            return null;
        }
        public override Sprite GetCostThirdEra()
        {
            return null;
        }
        public override Sprite GetInitialBonus()
        {
            return null;
        }

        public override Sprite GetCurrentEffect()
        {

            return null;
        }
    }
}