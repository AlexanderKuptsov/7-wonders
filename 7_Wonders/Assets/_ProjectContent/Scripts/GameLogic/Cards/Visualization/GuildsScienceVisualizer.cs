using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class GuildsScienceVisualizer : CardVisualizer<GuildsScienceCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundGuild = null;
       
        public GuildsScienceVisualizer(GuildsScienceCard data) : base(data)
        {

        }
        public override Color GetColor()
        {
            return new Color32(75,0,130,255);
        }

        public override Sprite GetBackground()
        {
         
            return  UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/background_guildcards.png");
        }

        public override Sprite GetCurrentEffect()
        {
            
            var actionInfo = cardData.CurrentEffect.ActionInfo;
            var SelectedItemIndex = cardData.CurrentEffect.SelectedItemIndex;
             
             
           //COMPASS / COG / STONE
           return UnityEngine.Resources.Load<Sprite> ("Effects/square_compass_cog_stone 1.png");


        }

        public override Sprite GetEndGameEffect()
        {
            //cardData.EndGameEffect.ScienceInfo.Currency;
            //cardData.EndGameEffect.ScienceInfo.Amount;
            throw new System.NotImplementedException();
        }
       
    }
}