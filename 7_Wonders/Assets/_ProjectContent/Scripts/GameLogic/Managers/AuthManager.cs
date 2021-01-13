using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic.Token;
using WhiteTeam.UI;

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

        private UserData _localUser;

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

        private void SaveLocalPlayerInfo(string token, UserData localPlayer)
        {
            TokenHolder.Instance.SaveToken(token);
            TokenHolder.Instance.SaveLocalPlayer(localPlayer);
        }

        #region NETWORK REQUESTS

        public void SendLoginRequest(string login, string password)
        {
            Debug.Log("Sending auth request");
            _localUser = new UserData(login);
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
            SaveLocalPlayerInfo(token, _localUser);
            Events.OnLogin.TriggerEvents();
        }

        public void OnRegister()
        {
            Events.OnSignUp.TriggerEvents();
        }

        public void OnError()
        {
            NotificationManager.Instance.Warning("Wrong Login or Password");
            Events.OnError.TriggerEvents();
        }

        #endregion
    }
}