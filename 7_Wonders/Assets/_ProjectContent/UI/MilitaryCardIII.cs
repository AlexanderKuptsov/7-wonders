using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName="MilitaryCard",menuName = "Cards/MilitaryCards/3")]
public class MilitaryCardIII : CardData
{
     public  SpecialCard<T> specialcard;
     public override Color change_color()
    {
      return  new Color32(255,0,0,255);
    }
}
