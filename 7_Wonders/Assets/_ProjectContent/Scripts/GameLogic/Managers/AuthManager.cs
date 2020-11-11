using SK_Engine;
using WhiteTeam.GameLogic.Token;

namespace WhiteTeam.GameLogic.Auth
{
    public class AuthManager : Singleton<AuthManager>
    {
        public readonly ActionsEvents Events = new ActionsEvents();

        public class ActionsEvents
        {
            public EventHolderBase OnLogin { get; } = new EventHolderBase();
            public EventHolderBase OnSignUp { get; } = new EventHolderBase();
            public EventHolderBase OnError { get; } = new EventHolderBase();
        }

        private void Start()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ServerModuleHandlerHTTP.Instance.Events.OnSuccessfulLogin.Subscribe(OnLogin);
            ServerModuleHandlerHTTP.Instance.Events.OnSuccessfulRegister.Subscribe(OnRegister);
            ServerModuleHandlerHTTP.Instance.Events.OnError.Subscribe(OnError);
        }

        private void SaveToken(string token)
        {
            TokenHolder.Instance.CreateToken(token);
        }

        #region NETWORK REQUESTS

        public void SendLoginRequest(string login, string password)
        {
            ServerModuleHandlerHTTP.Instance.AuthPost(login, password);
        }

        public void SendSignUpRequest(string login, string password)
        {
            ServerModuleHandlerHTTP.Instance.RegisterPost(login, password);
        }

        #endregion

        #region NETWORK EVENTS

        public void OnLogin(string token)
        {
            SaveToken(token);
            Events.OnLogin.TriggerEvents();
        }

        public void OnRegister()
        {
            Events.OnSignUp.TriggerEvents();
        }

        public void OnError()
        {
            Events.OnError.TriggerEvents();
        }

        #endregion
    }
}