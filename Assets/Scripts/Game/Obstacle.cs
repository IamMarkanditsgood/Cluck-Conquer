using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector2Int hpRange;

    public TMP_Text hpText;

    private int currentHP;

    public void StartGame()
    {
        gameObject.SetActive(true);
        currentHP = Random.Range(hpRange.x, hpRange.y + 1); // +1, бо верхня межа невключна
        hpText.text = currentHP.ToString();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            currentHP--;


            if (currentHP <= 0)
            {
                currentHP = 0;
                gameObject.SetActive(false);    
            }

            hpText.text = currentHP.ToString();
        }
    }
}
