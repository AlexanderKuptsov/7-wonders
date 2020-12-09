using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName="MilitaryCard",menuName = "Cards/MilitaryCards/3")]
public class MilitaryCardIII : CardData
{
    // Start is called before the first frame update
     public override Color change_color()
    {
      return  new Color32(255,0,0,255);
    }
}
