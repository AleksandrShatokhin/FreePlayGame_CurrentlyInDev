using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        WWW www = new WWW("http://localhost/SQLConnect/SaveData.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("Game Saved");
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }
    }
}
