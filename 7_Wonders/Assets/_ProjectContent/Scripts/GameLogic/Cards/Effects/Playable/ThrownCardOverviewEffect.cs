namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class ThrownCardOverviewEffect : CardEffect
    {
        public override void Activate(PlayerData player)
        {
            var thrownCards = CardsStack.GetThrownCards();
            // TODO
            throw new System.NotImplementedException();
        }
    }
}