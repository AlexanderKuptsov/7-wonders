using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[CreateAssetMenu (fileName="CivilianCard",menuName = "Cards/CivilianCards/2")]
public class CivilianCardsII : CardData
{
 
    public override Color change_color()
    {
      return  new Color32(0,191,255,255);
    }
}
