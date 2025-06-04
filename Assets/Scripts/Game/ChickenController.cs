using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public Transform _parant;

    [Header("Spawn Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private float spawnDelay = 0.5f;

    public bool isActive;

    private void Start()
    {
        StartCoroutine(SpawnTwoBulletsWithDelay());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }


    private IEnumerator SpawnTwoBulletsWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            if (isActive && bulletPrefab != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, spawnPoint1.position, Quaternion.identity);
                bullet.transform.SetParent(_parant);
            }
        }
    }
}
