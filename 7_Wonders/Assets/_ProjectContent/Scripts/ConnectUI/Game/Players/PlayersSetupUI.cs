using UnityEngine;
using WhiteTeam.ConnectingUI.Players;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Resources;

public class PlayersSetupUI : MonoBehaviour
{
    [SerializeField] private PlayerList playerList;

    private void Start()
    {
        var players = new[]
        {
            new PlayerData("1231", "Player 12", Role.CLIENT),
            new PlayerData("1243", "Player 234", Role.CLIENT),
            new PlayerData("656", "Player 2443", Role.CLIENT),
            new PlayerData("344", "Player 7453", Role.CLIENT),
            new PlayerData("866", "Player 5463", Role.CLIENT),
        };

        players[1].Resources.ChangeMoney(10);

        players[0].Resources.AddProduction(new Resource.CurrencyItem
            {Currency = Resource.CurrencyProducts.ORE, Amount = 5});

        playerList.AddPlayers(players);
    }
}