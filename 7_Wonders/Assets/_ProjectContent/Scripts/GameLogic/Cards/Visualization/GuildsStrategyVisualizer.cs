using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class GuildsStrategyVisualizer : CardVisualizer<GuildsStrategyCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundGuild = null;
       
        public GuildsStrategyVisualizer(GuildsStrategyCard data) : base(data)
        {
          
        }
        public override Color GetColor()
        {
            return new Color32(75,0,130,255);
        }

        public override Sprite GetBackground()
        {
          backgroundGuild.sprite   = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/background_guildcards.png");
            return backgroundGuild.sprite;
        }

        public override Sprite GetCurrentEffect()
        {
            
            var currentVictoryBonus = cardData.CurrentEffect.CurrentVictoryBonus;
            var playerDirections = cardData.CurrentEffect.PlayerDirection;
            throw new System.NotImplementedException();
        }

        public override Sprite GetEnGameEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}