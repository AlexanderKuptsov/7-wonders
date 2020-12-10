using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class RawMaterialVisualizer : CardVisualizer<RawMaterialsCard>
    {
        public RawMaterialVisualizer(RawMaterialsCard data) : base(data)
        {
        }

        public override Color GetColor()
        {
            return new Color32(139, 69, 19, 255);
        }

        public override Image GetCurrentEffect()
        {
            var currencyItems = cardData.CurrentEffect.ActionInfo;
            // TODO
            throw new System.NotImplementedException();
        }

        public override Image GetEnGameEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}