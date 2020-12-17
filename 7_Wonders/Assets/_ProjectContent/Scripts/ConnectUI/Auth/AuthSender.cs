using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Auth;
using WhiteTeam.UI;

public class AuthSender : MonoBehaviour
{
    public TMP_InputField loginField;
    public TMP_InputField pswdField;

    public TMP_InputField registerUsernameField;
    public TMP_InputField registerLoginField;
    public TMP_InputField registerPswdField;

    

    public void LogIn()
    {
        AuthManager.Instance.SendLoginRequest(loginField.text, pswdField.text);
        loginField.text = "";
        pswdField.text = "";
    }


    public void Register()
    {
        AuthManager.Instance.SendSignUpRequest(registerLoginField.text, registerPswdField.text);
        registerUsernameField.text = "";
        registerLoginField.text = "";
        registerPswdField.text = "";
    }
}
