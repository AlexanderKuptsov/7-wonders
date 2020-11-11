namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialCard : Card
    {
        protected override void UseAction(PlayerData player)
        {
            foreach (var currencyItem in data.ActionInfo)
            {
                player.Resources.AddMoney(currencyItem.Amount);
            }
        }
    }
}