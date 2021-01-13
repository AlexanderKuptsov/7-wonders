using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    // Start is called before the first frame update
 

    public GameObject resources;
      public bool isOpened = false;
 

    public void open_or_close()
    {

       if(!isOpened)
       {
          resources.SetActive(true);
          isOpened= true; 
       }
       
     else
      {
         resources.SetActive(false);
         isOpened = false;
      }
    }
}
