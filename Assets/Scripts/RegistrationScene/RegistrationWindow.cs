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
        ClearInputField();
        this.gameObject.SetActive(false);
        logInWindow.SetActive(true);
    }
}
