using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WhiteTeam.GameLogic.Auth;

public class AuthSceneChanger : SceneChanger
{
    void Start()
    {
        AuthManager.Instance.Events.OnLogin.Subscribe(OpenLobbyScene);
    }
    
}
