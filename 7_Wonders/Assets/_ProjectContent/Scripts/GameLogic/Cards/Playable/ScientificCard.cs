namespace WhiteTeam.GameLogic.Cards
{
    public class ScientificCard : Card
    {
        protected override void UseAction(PlayerData player)
        {
            foreach (var currencyItem in data.ActionInfo)
            {
                player.Resources.AddScience(currencyItem);
            }
        }
    }
}