using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    public interface ICard : INetworkEntity
    {
        #region NETWORK REQUESTS

        void UseRequest();
        void ActivatedUseRequest();

        #endregion

        #region ACTIONS

        void Use(PlayerData player);
        void ActivatedUse(PlayerData player);
        void ActivateEndGameEffect(PlayerData player);

        #endregion
    }
}