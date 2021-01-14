using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.GameLogic.Resources;

public class UpdateNeighboursResources : MonoBehaviour
{
    private PlayerData _leftPlayer;
    private PlayerData _rightPlayer;

    private bool _isSyncing;

    public void Sync()
    {
        _isSyncing = true;
        _leftPlayer = GameManager.Instance.CurrentSession.LocalPlayerData.LeftPlayerData;
        _rightPlayer = GameManager.Instance.CurrentSession.LocalPlayerData.RightPlayerData;
    }

    private void UpdateVisualizer()
    {
        LocalPlayerVisualizer.Instance.Show(GetLeftResources());
        LocalPlayerVisualizer.Instance.Show(GetRightResources());
    }

    private void Update()
    {
        if (!_isSyncing) return;
        UpdateVisualizer();
    }

    private OutputResources GetLeftResources() => _leftPlayer.Resources.GetCurrentResourcesState();
    private OutputResources GetRightResources() => _rightPlayer.Resources.GetCurrentResourcesState();
}