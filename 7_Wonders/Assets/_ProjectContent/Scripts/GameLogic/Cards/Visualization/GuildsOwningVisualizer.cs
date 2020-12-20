using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class GuildsOwningVisualizer : CardVisualizer<GuildsOwningCard>
    {
        public Sprite effectGuildsOwning = null;
       
        public GuildsOwningVisualizer(GuildsOwningCard data) : base(data)
        {

        }
        public override Color GetColor()
        {
            return new Color32(75,0,130,255);
        }

        public override Sprite GetBackground()
        {
            return UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/background_guildcards.png");
        }

        public override Sprite GetCurrentEffect()
        {
            
            var cardType = cardData.CurrentEffect.CardType;
            var currentMoneyBonus = cardData.CurrentEffect.CurrentMoneyBonus;
            var playerDirections = cardData.CurrentEffect.PlayerDirection;

             

             //GREY 1 GREEN 1 GUILD 1
             if ( playerDirections.Length == 0)
              {
              effectGuildsOwning = UnityEngine.Resources.Load<Sprite>("Effects/brown_grey_purple_one.png");

             }

            //PRODUCTION LEFT RIGHT ONE POINT
            if (cardType == CommonCardData.CardType.PRODUCTION && currentMoneyBonus == 1 && playerDirections.Length == 2 )
            {
              effectGuildsOwning = UnityEngine.Resources.Load<Sprite>("Effects/brown_arrows_one.png");

            }
            //PRODUCTION LEFT RIGHT TWO POINT
            if (cardType == CommonCardData.CardType.PRODUCTION && currentMoneyBonus == 2 && playerDirections.Length == 2 )
            {
              effectGuildsOwning = UnityEngine.Resources.Load<Sprite>("Effects/grey_card_arrows_two 1.png");

            }
            //MILITARY LEFT RIGHT ONE POINT
             if (cardType == CommonCardData.CardType.MILITARY && currentMoneyBonus == 1 && playerDirections.Length == 2 )
             {
              effectGuildsOwning = UnityEngine.Resources.Load<Sprite>("Effects/red_card_arrows_one.png");
             }
             //COMMERCIALTRADE LEFT RIGHT ONE POINT 
             if (cardType == CommonCardData.CardType.COMMERCIAL_TRADE && currentMoneyBonus == 1 && playerDirections.Length == 2 )
             {
              effectGuildsOwning = UnityEngine.Resources.Load<Sprite>("Effects/yellow_arrows_one.png");
             }
            //SCIENTIFIC LEFT RIGHT ONE POINT
             if (cardType == CommonCardData.CardType.SCIENTIFIC && currentMoneyBonus == 1 && playerDirections.Length == 2 )
             {
              effectGuildsOwning = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/green_card_arrows_one.png");
             }
             //CIVILIAN LEFT RIGHT ONE POINT
             if (cardType == CommonCardData.CardType.CIVILIAN && currentMoneyBonus == 1 && playerDirections.Length == 2 )
             {
              effectGuildsOwning = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/blue_card_arrows_one.png");
             }
 
                
            
            return effectGuildsOwning;
        }

        public override Sprite GetEndGameEffect()
        {
            //return  cardData.EndGameEffect.CurrentMoneyBonus;
            throw new System.NotImplementedException();
        }
      

       
    }
}