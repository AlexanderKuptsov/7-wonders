using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Scene]
    public string lobbyScene;
    
    public void OpenLobbyScene()
    {
        SceneManager.LoadScene(lobbyScene, LoadSceneMode.Single);
    }
}
