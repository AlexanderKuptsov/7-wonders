using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_game : MonoBehaviour
{
    public Sprite[] background = new Sprite[]{} ;
    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random();
        int rInts = r.Next(0,7);

        this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = background[rInts];
        
    }

    // Update is called once per frame
  
}
