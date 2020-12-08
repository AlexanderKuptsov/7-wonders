using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic.Auth;
using WhiteTeam.UI;

public class AuthSender : MonoBehaviour
{
    public TMP_InputField loginField;
    public TMP_InputField pswdField;

    
    public void LogIn()
    {
        //StartCoroutine(Spat());
        //NotificationManager.Instance.Warning("Wrong Login or Password");
        AuthManager.Instance.SendLoginRequest(loginField.text, pswdField.text);
        loginField.text = "";
        pswdField.text = "";
    }

    IEnumerator Spat()
    {
        AuthManager.Instance.SendSignUpRequest(loginField.text, pswdField.text);
        yield return new WaitForSeconds(2);
        AuthManager.Instance.SendLoginRequest(loginField.text, pswdField.text);
        loginField.text = "";
        pswdField.text = "";
    }
}
