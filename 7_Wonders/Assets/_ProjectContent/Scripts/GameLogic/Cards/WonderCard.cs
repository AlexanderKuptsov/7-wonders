using UnityEngine;
using WhiteTeam.GameLogic.Actions;

namespace WhiteTeam.GameLogic.Cards
{
    [CreateAssetMenu(fileName = "WonderCard", menuName = "Cards/Wonder", order = 0)]
    
    public class WonderCard : Card
    {
        public override Action Use()
        {
            throw new System.NotImplementedException();
        }
    }
}