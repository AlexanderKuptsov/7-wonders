using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
public class CivilianVisualizer :CardVisualizer<CivilianCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundCivilian = null;
        [SerializeField] private Sprite effectCivilian = null;

        [SerializeField] private string CardName = null;

        [SerializeField] private Sprite Cost = null;
       
        public CivilianVisualizer(CivilianCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return  new Color32(0,191,255,255);
        }

        public override Sprite GetBackground()
        {
          backgroundCivilian.sprite   = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/military_symbol.png");
            return backgroundCivilian.sprite;
        }

        public override Sprite GetCurrentEffect()
        {
            // TODO
             var victoryPoints = cardData.CurrentEffect.VictoryPoints;

             switch(victoryPoints)
             {
                 case 2:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number two.png");
                       break;
                case 3:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number three.png");
                       break;
                case 5:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number five.png");
                       break;
                case 6:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number six.png");
                       break;
                case 7:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number seven.png");
                       break;
                case 8:
                      effectCivilian = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Number eight.png");
                       break;
                default:
                      effectCivilian = null;
                       break;
              
             }
            return effectCivilian;
        }

        public override Sprite GetEndGameEffect()
        {
            

            throw new System.NotImplementedException();
        }

        public override string GetNameCard()
        {
            var namecard = cardData.Name;
            return namecard;
        }

        public override Sprite GetCost()
        {
           var cost = cardData.CostInfo;
           
         if (cost.Length == 1)
          {
           foreach(var costinfo in cost)
            {
                // STONE 1
               if(costinfo.Currency == Resources.Resource.CurrencyProducts.STONE && costinfo.Amount == 1)
               {
                   Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone.png");
               }
               // STONE 3
               if(costinfo.Currency == Resources.Resource.CurrencyProducts.STONE && costinfo.Amount == 3)
               {
                   Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_stone_stone.png");
               }
            }
          }
          
          if (cost.Length == 2)
          {
            for (int i = 0;i< cost.Length; i++)
            {
                //WOOD 1 ORE 2
                 if(cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
               {
                   if (cost[i+1].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i+1].Amount == 2 )
                   {
                       Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_ore_ore.png");
                   }
                   
               }
               // WOOD 1 CLAY 2
               if(cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
               {
                   if (cost[i+1].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i+1].Amount == 2 )
                   {
                       Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_brick_brick.png");
                   }
               }
               //CLAY 2 LOOM 1
               if(cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 2)
               {
                   if (cost[i+1].Currency == Resources.Resource.CurrencyProducts.CLOTH && cost[i+1].Amount == 1 )
                   {
                       Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/brick_brick_loom.png");
                   }
               }
              
            }
          }

          if (cost.Length == 3)
          {
            for(int i =0;i<cost.Length;i++)
            {
             //WOOD 1 CLAY 1 GLASS 1
              if(cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 1)
               {
                   i++;
                   if (cost[i].Currency == Resources.Resource.CurrencyProducts.CLAY && cost[i].Amount == 1 )
                   {
                       i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.GLASS && cost[i].Amount == 1 )
                            {
                                 Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_brick_glass.png");
                            }
                   }
               }
              //GLASS 1 ORE 1 STONE 2
                if(cost[i].Currency == Resources.Resource.CurrencyProducts.GLASS && cost[i].Amount == 1)
               {
                   i++;
                   if (cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 1 )
                   {
                       i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 2 )
                            {
                                 Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/glass_ore_stone_stone.png");
                            }
                   }
               }
               //ORE 1 STONE 1 WOOD 2
                if(cost[i].Currency == Resources.Resource.CurrencyProducts.ORE && cost[i].Amount == 1)
               {
                   i++;
                   if (cost[i].Currency == Resources.Resource.CurrencyProducts.STONE && cost[i].Amount == 1 )
                   {
                       i++;
                        if (cost[i].Currency == Resources.Resource.CurrencyProducts.WOOD && cost[i].Amount == 2 )
                            {
                                 Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/ore_stone_wood_wood.png");
                            }
                   }
               }

            }
          }
          //CLAY 2 ORE 1 PAPYRUS 1 LOOM 1 GLASS 1
           if (cost.Length == 5)
           {
               Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/brick_brick_loom_glass_ore_papyrus.png");
           }
         //GLASS 1 PAPYRUS 1 LOOM 1 WOOD 1 ORE 1 STONE 1
           if (cost.Length == 7)
           {
               Cost = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/glass_papyrus_loom_brick_wood_ore_stone.png");
           }
        return Cost;
        }

        
    }
}
