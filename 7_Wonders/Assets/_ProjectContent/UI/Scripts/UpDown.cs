using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpDown : MonoBehaviour
{
   public Button down_count_player;
   public  Button up_count_player;
   public TextMeshProUGUI countPlayer;
   public Button down_time_round;
   public Button up_time_round;
   public TextMeshProUGUI round_time;
   private int i =3;
   private int j = 15;
    
    public void downCountPlayer()
    {
        int limit = 3;
     
       
        if (i>limit)
        {
            i--;
            countPlayer.text = i.ToString();
        }

    }

    
    public void upCountPlayer()
    {
       int limit = 7;
        if (i<limit)
        {
            i++;
            countPlayer.text = i.ToString();
        }

    }

      public void down_round_time()
    {
        int limit = 15;
     
       
        if (j>limit)
        {
            j-=15;
            round_time.text = j.ToString() + " s";
        }

    }

    
    public void up_round_time()
    {
       int limit = 120;
        if (j<limit)
        {
            j+=15;
            round_time.text = j.ToString() +" s";
        }
    }

    public void resetTime()
    {
        j = 15;
        round_time.text = j.ToString() +" s";
    }

    public void resetMaxPlayers()
    {
        i = 3;
        countPlayer.text = i.ToString();
    }

    public int getTime()
    {
        return j;
    }
    
    public int getMaxPlayers()
    {
        return i;
    }
    
}
