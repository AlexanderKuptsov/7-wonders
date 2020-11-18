using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Actions
{
    public abstract class Action<T>
        where T : INetworkEntity
    {
        protected abstract void SendRequest(T entity, string command);

        public abstract string GetCommand();
    }
}