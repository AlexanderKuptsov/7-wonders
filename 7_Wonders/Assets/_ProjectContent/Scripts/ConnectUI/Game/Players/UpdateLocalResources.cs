using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.GameLogic.Resources;

public class UpdateLocalResources : Singleton<UpdateLocalResources>
{
    private PlayerData _localPlayer;

    private bool _isSyncing;

    public void Sync()
    {
        _isSyncing = true;
        _localPlayer = GameManager.Instance.CurrentSession.LocalPlayerData;
    }

    private void UpdateVisualizer()
    {
        LocalPlayerVisualizer.Instance.Show(GetResources());
    }

    private void Update()
    {
        if (!_isSyncing) return;
        UpdateVisualizer();
    }

    private OutputResources GetResources() => _localPlayer.Resources.GetSelfCurrentResourcesState();
}