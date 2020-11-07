using MyBox;
using UnityEngine;
using WhiteTeam.GameLogic.Actions;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class Card : ScriptableObject
    {
        [Foldout("Main settings")] 
        [SerializeField] private string title;
        public string Title => title;

        [SerializeField] private Sprite background;
        public Sprite Background => background;

        public abstract Action Use();
    }
}