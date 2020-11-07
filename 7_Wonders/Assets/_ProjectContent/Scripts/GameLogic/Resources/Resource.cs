using System;
using MyBox;
using UnityEngine;

namespace WhiteTeam.GameLogic.Resources
{
    [Serializable]
    public class Resource
    {
        [SerializeField] [PositiveValueOnly] private int value;

        public int Value
        {
            get => value;
            set => this.value = value;
        }

        public Resource()
        {
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
            value = Mathf.Max(value - amount, 0);
        }
    }
}