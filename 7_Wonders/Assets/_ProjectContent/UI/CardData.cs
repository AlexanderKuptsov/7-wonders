using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardData : ScriptableObject
{
   public Image color;

   public string cardname;
   public Sprite effect;
   public Sprite costeffect;

    public abstract Color change_color();
   
}
