using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName ="Grey Cards", menuName="Cards/GreyCards/2")]
public class GreyCardII : CardData

{
    public override Color change_color()
   {
    
      return new Color32(192,192,192,255);
   }
   
}
