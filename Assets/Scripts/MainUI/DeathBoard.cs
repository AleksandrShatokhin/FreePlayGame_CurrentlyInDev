using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class DeathBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCountScore;
    [SerializeField] private Button buttonRestart, buttonExit;
    private int score;

    private void Start()
    {
        buttonRestart.onClick.AddListener(RestartLevel);
        buttonExit.onClick.AddListener(Exit);

        score = GameController.GetInstance().GetReferencesToComponent().GetMainUIController().GetCountEnemy();
        textCountScore.text = score.ToString();
    }

    private void RestartLevel()
    {
        StartCoroutine(SaveData());
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1");
    }

    private void Exit()
    {
        StartCoroutine(SaveData());
        UnityEngine.SceneManagement.SceneManager.LoadScene("Registration");
        DataBaseInformation.LogOut();
    }

    private IEnumerator SaveData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DataBaseInformation.userName);
        form.AddField("score", score);

        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/SQLConnect/SaveData.php", form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Game Saved");
            }
        }
    }
}
