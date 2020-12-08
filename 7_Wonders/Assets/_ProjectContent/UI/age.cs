using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class age : MonoBehaviour
{
    public Sprite[] age_game = new Sprite[]{} ;
    // Start is called before the first frame update
    void Start()
    {
        //When the first round will be over, then we'll change the age number and arrow direction
        System.Random r = new System.Random();
        int rInts = r.Next(0,2);

        this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = age_game[rInts];
        
    }

    // Update is called once per frame
  
}
