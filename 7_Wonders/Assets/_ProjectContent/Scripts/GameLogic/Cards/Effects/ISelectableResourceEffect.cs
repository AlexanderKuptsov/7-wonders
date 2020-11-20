using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Effects
{
    public interface ISelectableResourceEffect<T>
    {
        Resource.CurrencyBaseData<T> Select();
    }
}