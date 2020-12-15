using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


namespace WhiteTeam.GameLogic.Cards.Visualization
{
public class MilitaryVisualizer : CardVisualizer<MilitaryCard>
    {
        [SerializeField] private UnityEngine.UI.Image backgroundMilitary = null;
        [SerializeField] private Sprite effectMilitary = null;

        [SerializeField] private string CardName = null;

        [SerializeField] private Sprite CosteffectMilitary = null;

        public MilitaryVisualizer(MilitaryCard data) : base(data)
        {

        }

        public override Color GetColor()
        {
            return  new Color32(255,0,0,255);
        }

        public override Sprite GetBackground()
        {
            
          backgroundMilitary.sprite   = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Pictures/military_symbol.png");
            return backgroundMilitary.sprite;
        }

        public override  Sprite GetCurrentEffect()
        {
             var shield = cardData.CurrentEffect.Shields;
                switch(shield)
                {
                    case 1 :
                        effectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/shield.png");
                        break;
                    case 2 :
                        effectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/shield_shield.png");
                        break;
                    case 3 :
                        effectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/shield_shield_shield.png");
                        break;
                    default:
                         effectMilitary = null;
                         break;
                }
             
            return effectMilitary;
        }

        public override Sprite GetEndGameEffect()
        {
            throw new System.NotImplementedException();
        }

        public override string GetNameCard()
        {
            return cardData.Name;
        }

        public override Sprite GetCost()
        {
            var costInfo = cardData.CostInfo;

            if(costInfo.Length == 1)
            {
                foreach(var cost in costInfo)
                {
                    if(cost.Currency == Resources.Resource.CurrencyProducts.WOOD && cost.Amount == 1 )
                        CosteffectMilitary =UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Wood.png");
                    if(cost.Currency == Resources.Resource.CurrencyProducts.ORE && cost.Amount == 1 )
                        CosteffectMilitary =UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/Gold ore.png");
                    if(cost.Currency == Resources.Resource.CurrencyProducts.CLAY && cost.Amount == 1 )
                        CosteffectMilitary =UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/brick.png");
                    if(cost.Currency == Resources.Resource.CurrencyProducts.STONE && cost.Amount == 3 )
                        CosteffectMilitary =UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_stone_stone.png");
                }
            }

            if(costInfo.Length == 2)
            {
                //WOOD 1 ORE 2
                for(int i=0;i<costInfo.Length;i++)
                {     
                    if(costInfo[i].Currency== Resources.Resource.CurrencyProducts.WOOD && costInfo[i].Amount == 1 )
                    {
                        if(costInfo[i+1].Currency == Resources.Resource.CurrencyProducts.ORE && costInfo[i+1].Amount == 2)
                        {
                            CosteffectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_ore_ore.png");
                        }
                    
                    }
                    //STONE 1 ORE 3
                    if(costInfo[i].Currency== Resources.Resource.CurrencyProducts.STONE && costInfo[i].Amount == 1 )
                    {
                        if(costInfo[i+1].Currency == Resources.Resource.CurrencyProducts.ORE && costInfo[i+1].Amount == 3)
                        {
                            CosteffectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_ore_ore_ore.png");
                        }
                    }
                    //STONE 3 ORE 1
                     if(costInfo[i].Currency== Resources.Resource.CurrencyProducts.STONE && costInfo[i].Amount == 3 )
                    {
                        if(costInfo[i+1].Currency == Resources.Resource.CurrencyProducts.ORE && costInfo[i+1].Amount == 1)
                        {
                            CosteffectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/stone_stone_stone_ore.png");
                        }
                    }
                    //WOOD 2 ORE 1
                     if(costInfo[i].Currency== Resources.Resource.CurrencyProducts.WOOD && costInfo[i].Amount == 2 )
                    {
                        if(costInfo[i+1].Currency == Resources.Resource.CurrencyProducts.ORE && costInfo[i+1].Amount == 1)
                        {
                            CosteffectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_wood_ore.png");
                        }
                    }
                    //WOOD 1 CLAY 3
                     if(costInfo[i].Currency== Resources.Resource.CurrencyProducts.WOOD && costInfo[i].Amount == 1 )
                    {
                        if(costInfo[i+1].Currency == Resources.Resource.CurrencyProducts.CLAY && costInfo[i+1].Amount == 3)
                        {
                           CosteffectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/wood_brick_brick_brick.png");
                        }
                    }
                }
               }

            if(costInfo.Length == 3)
            {
                
                for(int i=0;i<costInfo.Length;i++)
                {
                    //ORE 1 CLAY 1 WOOD 1 
                     if(costInfo[i].Currency== Resources.Resource.CurrencyProducts.ORE && costInfo[i].Amount == 1 )
                    {
                        i++;
                        if(costInfo[i].Currency == Resources.Resource.CurrencyProducts.CLAY && costInfo[i].Amount == 1)
                        {
                            i++;
                            if(costInfo[i].Currency == Resources.Resource.CurrencyProducts.WOOD && costInfo[i].Amount == 1)
                            {
                                CosteffectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/ore_brick_wood.png");
                            }      
                        }
                    }
                     //ORE 1 WOOD 2 LOOM 1
                     if(costInfo[i].Currency== Resources.Resource.CurrencyProducts.ORE && costInfo[i].Amount == 1 )
                    {
                        i++;
                        if(costInfo[i].Currency == Resources.Resource.CurrencyProducts.WOOD && costInfo[i].Amount == 2)
                        {
                            i++;
                            if(costInfo[i].Currency == Resources.Resource.CurrencyProducts.CLOTH && costInfo[i].Amount == 1)
                            {
                                CosteffectMilitary = UnityEngine.Resources.Load<Sprite>("Assets/_ProjectContent/UI/Resources/Effects/ore_wood_wood_loom.png");
                            }      
                        }
                    }

                }
            }
   
     return CosteffectMilitary;
   }

}

}
