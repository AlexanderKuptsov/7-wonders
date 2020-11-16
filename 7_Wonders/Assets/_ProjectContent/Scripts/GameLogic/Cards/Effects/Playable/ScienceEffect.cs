using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class ScienceEffect : CardEffect
    {
        public Resource.ScienceItem ScienceInfo;

        public ScienceEffect(Resource.ScienceItem scienceInfo)
        {
            ScienceInfo = scienceInfo;
        }
        
        public override void Activate(PlayerData player)
        {
            player.Resources.AddScience(ScienceInfo);
        }
    }
}