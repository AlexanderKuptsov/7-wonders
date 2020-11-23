using UnityEngine;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class CardWrapper<T> : MonoBehaviour, ICard
        where T : CardData
    {
        public T Data;

        public abstract void UseRequest();
        public abstract void ActivatedUseRequest();
        public abstract void Use(PlayerData player);
        public abstract void ActivatedUse(PlayerData player);
        public abstract void ActivateEndGameEffect(PlayerData player);

        public IdentifierInfo GetIdentifierInfo() => Data.GetIdentifierInfo();
    }
}