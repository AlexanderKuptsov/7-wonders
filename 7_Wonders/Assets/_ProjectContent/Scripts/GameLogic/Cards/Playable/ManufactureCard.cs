namespace WhiteTeam.GameLogic.Cards
{
    public class ManufactureCard : Card
    {
        protected override void UseAction(PlayerData player)
        {
            foreach (var currencyItem in data.ActionInfo)
            {
                player.Resources.AddProduction(currencyItem);
            }
        }
    }
}