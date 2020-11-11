using System;
using MyBox;
using UnityEngine;

namespace WhiteTeam.GameLogic.Resources
{
    [Serializable]
    public class Resource
    {
        [SerializeField] [PositiveValueOnly] private int value;

        private const int MIN_VALUE = 0;

        public int Value
        {
            get => value;
            set => this.value = value;
        }

        public Resource()
        {
            value = MIN_VALUE;
        }

        public Resource(int value)
        {
            this.value = value;
        }

        public void Increase(int amount)
        {
            value += amount;
        }

        public void Decrease(int amount)
        {
            value = Mathf.Max(value - amount, MIN_VALUE);
        }

        public void Clear()
        {
            value = MIN_VALUE;
        }

        public enum Currency
        {
            MONEY,
            MILITARY,
            VICTORY,

            // RawMaterial
            WOOD,
            ORE,
            CLAY,
            STONE,

            // Products
            PAPYRUS,
            CLOTH,
            GLASS,

            //Science
            RUNE_1,
            RUNE_2,
            RUNE_3
        }

        [Serializable]
        public struct CurrencyItem
        {
            [ReadOnly] public Currency Currency;
            [ReadOnly] public int Amount;
        }
    }
}