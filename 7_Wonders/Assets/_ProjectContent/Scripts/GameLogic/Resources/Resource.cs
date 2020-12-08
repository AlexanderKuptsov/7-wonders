using System;
using MyBox;
using UnityEngine;

namespace WhiteTeam.GameLogic.Resources
{
    [Serializable]
    public class Resource
    {
        [SerializeField] [PositiveValueOnly] private int value;

        private const int DEFAULT_VALUE = 0;

        public int Value
        {
            get => value;
            set => this.value = value;
        }

        public Resource()
        {
            value = DEFAULT_VALUE;
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
            //value = Mathf.Max(value - amount, DEFAULT_VALUE);
            value -= amount;
        }

        public void Clear()
        {
            value = DEFAULT_VALUE;
        }

        public enum CurrencyProducts
        {
            MONEY,
            
            // RawMaterial
            WOOD,
            ORE,
            CLAY,
            STONE,

            // Products
            PAPYRUS,
            CLOTH,
            GLASS,
        }

        public enum Science
        {
            RUNE_1,
            RUNE_2,
            RUNE_3
        }

        [Serializable]
        public abstract class CurrencyBaseData<T>
        {
            [ReadOnly] public T Currency;
            [ReadOnly] public int Amount;
        }

        public class CurrencyItem : CurrencyBaseData<CurrencyProducts>
        {
        }

        public class ScienceItem : CurrencyBaseData<Science>
        {
        }
    }
}