using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.GameLogic.Resources;

public class UpdateNeighboursResources : Singleton<UpdateNeighboursResources>
{
    [SerializeField] private NeigboursVisualizer leftVisualizer;
    [SerializeField] private NeigboursVisualizer rightVisualizer;
    
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
        leftVisualizer.Show(_leftPlayer.Name, GetLeftResources());
        rightVisualizer.Show(_rightPlayer.Name, GetRightResources());
    }

    private void Update()
    {
        if (!_isSyncing) return;
        UpdateVisualizer();
    }

    private OutputResources GetLeftResources() => _leftPlayer.Resources.GetCurrentResourcesState();
    private OutputResources GetRightResources() => _rightPlayer.Resources.GetCurrentResourcesState();
}