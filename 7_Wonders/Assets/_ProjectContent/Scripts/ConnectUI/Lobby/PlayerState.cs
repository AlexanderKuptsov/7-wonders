using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private Image stateImage;
    private Color readyColor = new Color(23/255.0f, 230/255.0f, 60/255.0f, 75/255.0f);
    private Color notReadyColor = new Color(23/255.0f, 230/255.0f, 60/255.0f, 0);

    public void changeState()
    {
        stateImage.color = stateImage.color == readyColor ? notReadyColor : readyColor;
    }

    public void setReadyState()
    {
        stateImage.GetComponent<Image>().color = readyColor;
    }

    public void setNotReadyState()
    {
        stateImage.GetComponent<Image>().color = notReadyColor;
    }
}
