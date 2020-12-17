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
          backgroundGuild.sprite   = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/background_guildcards.png");
            return backgroundGuild.sprite;
        }

        public override Sprite GetCurrentEffect()
        {
            
            var actionInfo = cardData.CurrentEffect.ActionInfo;
            var SelectedItemIndex = cardData.CurrentEffect.SelectedItemIndex;
            throw new System.NotImplementedException();
        }

        public override Sprite GetEndGameEffect()
        {
            throw new System.NotImplementedException();
        }
        public override string GetNameCard()
        {
            throw new System.NotImplementedException();
        }

        public override Sprite GetCost()
        {
            throw new System.NotImplementedException();
        }
    }
}