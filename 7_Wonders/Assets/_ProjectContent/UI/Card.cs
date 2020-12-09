using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
  //public Transform prefab;
    // Start is called before the first frame update
    void Start ()
    {
        for (int i =0 ;i< 10;i++)
        {
          //Instantiate(this, new Vector3(i*2.0F,0,0),Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
      transform.Rotate(new Vector3(0f, 100f,0f)*Time.deltaTime);  
    }
}
