using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ServerButton : MonoBehaviour
{
    public TMP_Text btnText;
    private bool _isOn = false;
    private const string Off = "Работа сервера: Выкл";
    private const string On = "Работа сервера: Вкл";

    public void TurnOnOff()
    {
        if (_isOn)
        {
            btnText.text = Off;
        }
        else
        {
            btnText.text = On;
        }

        _isOn = !_isOn;
    }
}