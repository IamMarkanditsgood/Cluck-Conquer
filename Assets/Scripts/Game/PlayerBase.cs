using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public GameScreen GameScreen;

    public int health = 100;
    public bool isActive;

    public void Toggle(bool state)
    {
        isActive = state;
        if(isActive)
        {
            health = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);

            if (isActive)
            {
                health--;


                if (health <= 0)
                {
                    health = 0;
                    GameScreen.FinishGame(false);
                }
            }
        }
    }

}
