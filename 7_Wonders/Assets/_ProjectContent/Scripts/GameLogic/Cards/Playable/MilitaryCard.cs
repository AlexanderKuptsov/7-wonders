using MyBox;

namespace WhiteTeam.GameLogic.Cards
{
    public class MilitaryCard : CardData
    {
        [ReadOnly] public int Shilds;
        
        public override void Use(PlayerData player)
        {
            player.Resources.AddMilitary(Shilds);
        }
    }
}