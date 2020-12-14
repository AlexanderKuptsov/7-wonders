using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName="New Card",menuName="Cards/RawMaterials/2")]
public class CardRawMaterialsAgeII: CardData
{
   

   public override Color change_color()
   {
      return new Color32(139,69,19,255);
   }
  
}
