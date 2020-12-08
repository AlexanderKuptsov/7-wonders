namespace WhiteTeam.GameLogic.Cards.Effects
{
    public abstract class SelectableCardEffect<T> : BaseSelectableCardEffect
    {
        public readonly T[] ActionInfo;

        public int SelectedItemIndex;
        public T SelectedItem => ActionInfo[SelectedItemIndex];

        public SelectableCardEffect(T[] actionInfo)
        {
            ActionInfo = actionInfo;
            SelectedItemIndex = 0;
        }

        public override void Activate(PlayerData player)
        {
            ActivateSelected(player);
        }

        public override void Select(PlayerData player)
        {
            DeactivateSelected(player);
            ChangeSelection();
            ActivateSelected(player);
        }

        protected abstract void DeactivateSelected(PlayerData player);

        protected abstract void ActivateSelected(PlayerData player);

        private void ChangeSelection()
        {
            SelectedItemIndex = SelectedItemIndex == ActionInfo.Length - 1 ? 0 : SelectedItemIndex + 1;
        }
    }
}