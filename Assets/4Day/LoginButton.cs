using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginButton : MonoBehaviour
{
    public TMP_InputField inputField_ID;
    public TMP_InputField inputField_PW;

    public bool ServerCheck(string id, string pw)
    {
        if (id == "test" && pw == "1234")
        {
            return true;
        }
        return false;
    }

    public void InputLoginButton()
    {
        string inputID = inputField_ID.text;
        string inputPW = inputField_PW.text;

        bool isLoginCheck = ServerCheck(inputID, inputPW);

        if (isLoginCheck)
        {
            SceneManager.LoadScene("AimLab");
        }
        else
        {
            print("아이디 혹은 비밀번호가 틀렸습니다.");
            inputField_ID.text = "";
            inputField_PW.text = "";
        }
    }
}
