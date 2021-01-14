using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic;

public class CreateLobbyManager : MonoBehaviour
{
    public TMP_InputField lobbyName;
    public UpDown createLobbyController;

    public void clearCreateParameters()
    {
        lobbyName.text = "";
        createLobbyController.resetTime();
        createLobbyController.resetMaxPlayers();
    }

    public void CreateLobby()
    {
        if (LobbyManager.Instance.LocalUserData.Name == null)
        {
            FakeLobbyServer.Instance.FakeOurCreate("OurName",
                new GameSettings(lobbyName.text, createLobbyController.getMaxPlayers(),
                    createLobbyController.getTime())); // Get localPlayer
            clearCreateParameters();
        }
        else
        {
            FakeLobbyServer.Instance.FakeOurCreate(LobbyManager.Instance.LocalUserData.Name,
                new GameSettings(lobbyName.text, createLobbyController.getMaxPlayers(),
                    createLobbyController.getTime()));
            clearCreateParameters();
        }
    }
}