using UnityEngine;
using UnityEngine.SceneManagement;

namespace WhiteTeam.ConnectingUI
{
    public class SceneChanger : MonoBehaviour
    {
        [Scene] public string authScene;

        [Scene] public string lobbyScene;

        [Scene] public string gameScene;

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
            SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
        }
    }
}