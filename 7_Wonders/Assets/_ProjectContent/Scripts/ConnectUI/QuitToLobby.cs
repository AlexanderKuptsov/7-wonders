using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WhiteTeam.ConnectingUI;

public class QuitToLobby : MonoBehaviour
{

    public void ChangeSceneToLobby()
    {
        SceneChanger.Instance.OpenLobbyScene();
    }
}
