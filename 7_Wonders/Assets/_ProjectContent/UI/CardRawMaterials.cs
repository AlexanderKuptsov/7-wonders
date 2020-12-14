using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName="New Card",menuName="Cards/RawMaterials/1")]
public class CardRawMaterials : CardData

{
   public override Color change_color()
   {
      return  new Color32(139,69,19,255);
   }

}
