using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class GuildsStrategyVisualizer : CardVisualizer<GuildsStrategyCard>
    {
       
       
        public GuildsStrategyVisualizer(GuildsStrategyCard data) : base(data)
        {
          
        }
        public override Color GetColor()
        {
            return new Color32(75,0,130,255);
        }

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite> ("Pictures/background_guildcards.png");
        }

        public override Sprite GetCurrentEffect()
        {
            
            var currentVictoryBonus = cardData.CurrentEffect.CurrentVictoryBonus;
            var playerDirections = cardData.CurrentEffect.PlayerDirection;

            return UnityEngine.Resources.Load<Sprite>("Effects/minus_one_arrows.png");
        
        }

        public override Sprite GetEndGameEffect()
        {
            //cardData.EndGameEffect.CurrentVictoryBonus;
            //cardData.EndGameEffect.PlayerDirection;
            throw new System.NotImplementedException();
        }

     
    }
}