using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName="CivilianCard",menuName = "Cards/CivilianCards/3")]

public class CivilianCardsIII : CardData
{
    // Start is called before the first frame update
    public override Color change_color()
    {
      return  new Color32(0,191,255,255);
    }
}
