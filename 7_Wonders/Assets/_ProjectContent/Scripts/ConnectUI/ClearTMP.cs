using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearTMP : MonoBehaviour
{
    public void Clear()
    {
        GetComponent<TMP_InputField>().text = "";
    }
}
