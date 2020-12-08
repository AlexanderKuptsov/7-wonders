using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.Network.ServerModules;

public class LobbyTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ServerLobbyHandler.Instance.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
