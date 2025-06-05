using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public Transform _parant;
    [Header("Movement Settings")]
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;
    [SerializeField] private float speed = 2f;

    [Header("Spawn Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private float spawnDelay = 0.5f;

    private bool movingRight = true;

    void Update()
    {
        Move();
    }


    private void Move()
    {
        float direction = movingRight ? 1f : -1f;
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (transform.position.x >= maxX)
            movingRight = false;
        else if (transform.position.x <= minX)
            movingRight = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Знищуємо стару кулю
            StartCoroutine(SpawnTwoBulletsWithDelay());
        }
    }

    private IEnumerator SpawnTwoBulletsWithDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint1.position, Quaternion.identity);
            bullet.transform.SetParent(_parant);
        }

        yield return new WaitForSeconds(spawnDelay);
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint2.position, Quaternion.identity);
            bullet.transform.SetParent(_parant);
        }
    }
}
