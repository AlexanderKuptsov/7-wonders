using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Actions
{
    public abstract class Action<T> : INetworkAction
        where T : INetworkEntity
    {
        protected readonly T _entity;

        public Action(T entity)
        {
            _entity = entity;
        }

        public void SenRequest()
        {
            SendRequest(_entity, GetCommand());
        }

        protected abstract void SendRequest(T entity, string command);

        public abstract string GetCommand();
    }
}