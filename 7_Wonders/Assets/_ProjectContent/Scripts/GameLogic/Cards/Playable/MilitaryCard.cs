namespace WhiteTeam.GameLogic.Cards
{
    public class MilitaryCard : Card
    {
        protected override void UseAction(PlayerData player)
        {
            foreach (var currencyItem in data.ActionInfo)
            {
                player.Resources.AddMilitary(currencyItem.Amount);
            }
        }
    }
}