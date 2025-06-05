using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBalanceSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public EnemyController enemyController;
    public PlayerBase player;   

    private int playerHP;
    private int enemyHP;

    void Start()
    {
        UpdateSlider();
    }

    private void Update()
    {
        playerHP = player.health;
        enemyHP = enemyController.health;
        UpdateSlider();

    }


    private void UpdateSlider()
    {
        float total = playerHP + enemyHP;
        slider.value = (total > 0) ? (float)enemyHP / total : 0.5f;
    }
}
