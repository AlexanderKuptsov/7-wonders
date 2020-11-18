namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class MoneyEffect : CardEffect
    {
        public readonly int Coins;

        public MoneyEffect(int coins)
        {
            Coins = coins;
        }

        public override void Activate(PlayerData player)
        {
            player.Resources.ChangeMoney(Coins);
        }
    }
}