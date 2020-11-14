using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public abstract class CardVisualizer<T> : MonoBehaviour
        where T : CardData
    {
        public T CardData;
    }
}