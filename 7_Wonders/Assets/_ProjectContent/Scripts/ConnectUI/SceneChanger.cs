using UnityEngine;
using UnityEngine.SceneManagement;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Auth;

namespace WhiteTeam.ConnectingUI
{
    public class SceneChanger : Singleton<SceneChanger>
    {
        [Scene] public string authScene;

        [Scene] public string lobbyScene;

        [Scene] public string gameScene;

        
        void Start()
        {
            AuthManager.Instance.Events.OnLogin.Subscribe(OpenLobbyScene);
            LobbyManager.Instance.Events.OnStartLobby.Subscribe(OpenGameScene);
        }
        public void OpenAuthScene()
        {
            SceneManager.LoadScene(authScene, LoadSceneMode.Single);
        }

        public void OpenLobbyScene()
        {
            SceneManager.LoadScene(lobbyScene, LoadSceneMode.Single);
        }

        public void OpenGameScene()
        {
            Debug.Log("AAAAAAAAAAA");
            SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
        }
    }
}