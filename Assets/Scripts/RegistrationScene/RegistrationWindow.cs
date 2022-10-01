using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegistrationWindow : MonoBehaviour
{
    [SerializeField] private GameObject logInWindow;
    [SerializeField] private TMP_InputField inputFieldLogin, inputFieldPassword;

    private void ClearInputField()
    {
        inputFieldLogin.text = null;
        inputFieldPassword.text = null;
    }

    public void OnSelectLoginField(TextMeshProUGUI placeHolder)
    {
        placeHolder.text = null;
    }

    public void OnDeselectLoginField(TextMeshProUGUI placeHolder)
    {
        placeHolder.text = "Enter Login...";
    }

    public void OnSelectPasswordField(TextMeshProUGUI placeHolder)
    {
        placeHolder.text = null;
    }

    public void OnDeselectPasswordField(TextMeshProUGUI placeHolder)
    {
        placeHolder.text = "Enter password...";
    }

    public void OnClickButtonCreateAccount()
    {
        if (VerifyInput())
        {
            StartCoroutine(Register());
        }
        else
        {
            Debug.Log("¬ведены неправильные значени€");
        }

        ClearInputField();
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", inputFieldLogin.text);
        form.AddField("password", inputFieldPassword.text);

        WWW www = new WWW("http://localhost/SQLConnect/Register.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("User created!");

            this.gameObject.SetActive(false);
            logInWindow.SetActive(true);
        }
        else
        {
            Debug.Log("User created failed. Error #" + www.text);
        }
    }

    private bool VerifyInput()
    {
        bool isInputCorrectText = inputFieldLogin.text.Length >= 4 && inputFieldPassword.text.Length >= 8 ? true : false;
        return isInputCorrectText;
    }
}
