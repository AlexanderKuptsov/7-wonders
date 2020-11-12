using MyBox;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialMoneyCard : CommercialCard
    {
        [ReadOnly] public int Coins;
        
        public override void Use(PlayerData player)
        {
            player.Resources.AddMoney(Coins);
        }
    }
}