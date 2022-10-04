using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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

        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/SQLConnect/Register.php", form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                this.gameObject.SetActive(false);
                logInWindow.SetActive(true);
            }
        }
    }

    private bool VerifyInput()
    {
        bool isInputCorrectText = inputFieldLogin.text.Length >= 4 && inputFieldPassword.text.Length >= 8 ? true : false;
        return isInputCorrectText;
    }
}
