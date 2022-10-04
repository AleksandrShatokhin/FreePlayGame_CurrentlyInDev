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
        StartCoroutine(Login());
    }

    public void OnCliskButtonOpenRegistrationWindow()
    {
        ClearInputField();
        this.gameObject.SetActive(false);
        registrationWindow.SetActive(true);
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", inputFieldLogin.text);
        form.AddField("password", inputFieldPassword.text);

        WWW www = new WWW("http://localhost/SQLConnect/Login.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            DataBaseInformation.userName = inputFieldLogin.text;
            DataBaseInformation.score = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene("Level_1");
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    private bool VerifyInput()
    {
        bool isInputCorrectText = inputFieldLogin.text == null && inputFieldPassword.text == null ? true : false;
        return isInputCorrectText;
    }
}
