using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogInWindow : MonoBehaviour
{
    [SerializeField] private GameObject registrationWindow;
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

    public void OnClickButtonLogIn()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OnCliskButtonOpenRegistrationWindow()
    {
        ClearInputField();
        this.gameObject.SetActive(false);
        registrationWindow.SetActive(true);
    }
}
