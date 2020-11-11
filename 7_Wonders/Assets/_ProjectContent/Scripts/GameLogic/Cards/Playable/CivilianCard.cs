namespace WhiteTeam.GameLogic.Cards
{
    public class CivilianCard : Card
    {
        protected override void UseAction(PlayerData player)
        {
            foreach (var currencyItem in data.ActionInfo)
            {
                player.Resources.AddCivilian(currencyItem.Amount);
            }
        }
    }
}