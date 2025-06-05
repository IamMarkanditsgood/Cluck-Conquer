using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameScreen GameScreen;

    public Transform[] bulletSpawnPoints;
    [SerializeField] private GameObject[] bulletPrefabs;
    [SerializeField] private Vector2 spawnDelay;
    public Transform _parant;

    public int health = 100;
    public bool isActive;


    private void Start()
    {
        StartCoroutine(BulletSpawner());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    public void StartGame()
    {
        gameObject.SetActive(true);
    }
    public void Toggle(bool state)
    {
        isActive = state;
        if (isActive)
        {
            health = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            if (isActive)
            {
                health--;


                if (health <= 0)
                {
                    health = 0;
                    GameScreen.FinishGame(true);
                }
            }
        }
    }

    private IEnumerator BulletSpawner()
    {
        while (true)
        {
            float randomDelay = Random.Range(spawnDelay.x, spawnDelay.y + 1);
            yield return new WaitForSeconds(randomDelay);

            if (isActive)
            {
                int randomBullet = Random.Range(0, bulletPrefabs.Length);
                GameObject bulletPref = bulletPrefabs[randomBullet];

                int centerIndex = bulletSpawnPoints.Length / 2;
                int randomSpawnPoint = Random.Range(1, bulletSpawnPoints.Length + 1); // +1, щоб включити 5

                List<int> spawnIndexes = new List<int> { centerIndex };

                // Розширюємось вліво і вправо від центру
                for (int offset = 1; spawnIndexes.Count < randomSpawnPoint; offset++)
                {
                    int leftIndex = centerIndex - offset;
                    int rightIndex = centerIndex + offset;

                    if (leftIndex >= 0 && spawnIndexes.Count < randomSpawnPoint)
                        spawnIndexes.Add(leftIndex);

                    if (rightIndex < bulletSpawnPoints.Length && spawnIndexes.Count < randomSpawnPoint)
                        spawnIndexes.Add(rightIndex);
                }

                // Спавнимо кулі у вибраних точках
                foreach (int i in spawnIndexes)
                {
                    Transform spawnPoint = bulletSpawnPoints[i];
                    GameObject bullet = Instantiate(bulletPref, spawnPoint.position, Quaternion.identity);
                    bullet.transform.SetParent(_parant);
                }
            }
        }
    }
}
