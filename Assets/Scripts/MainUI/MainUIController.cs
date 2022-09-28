using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private Slider sliderHealthPlayer;

    [SerializeField] private TextMeshProUGUI counterEnemyKills;
    private int countEnemy = 0;
    private const string textEnemyKills = "Врагов убито: ";

    private void Start()
    {
        sliderHealthPlayer.value = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthComponent>().GetHealth();
        ChangeTextEnemyKills(countEnemy);
    }

    public void ChangePlayerHealthBar(int damage) => sliderHealthPlayer.value -= damage;
    public void ChangeTextEnemyKills(int count)
    {
        countEnemy += count;
        counterEnemyKills.text = textEnemyKills + countEnemy;
    }
}
