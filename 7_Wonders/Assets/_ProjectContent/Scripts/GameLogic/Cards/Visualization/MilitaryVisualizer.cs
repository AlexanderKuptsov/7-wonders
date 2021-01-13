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
            return new Color32(255, 0, 0, 255);
        }

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite>("Pictures/military_symbol");
        }

        public override Sprite GetCurrentEffect()
        {
            var shield = cardData.CurrentEffect.Shields;
            switch (shield)
            {
                case 1:
                    effectMilitary = UnityEngine.Resources.Load<Sprite>("Effects/shield");
                    break;
                case 2:
                    effectMilitary = UnityEngine.Resources.Load<Sprite>("Effects/shield_shield");
                    break;
                case 3:
                    effectMilitary = UnityEngine.Resources.Load<Sprite>("Effects/shield_shield_shield");
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