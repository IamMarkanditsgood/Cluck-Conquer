using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float speed = 5f;

    public string EnemyBulletTag;

    public enum Direction
    {
        Up,
        Down
    }

    [SerializeField] private Direction moveDirection = Direction.Up;

    private void Start()
    {
        GlobalEvents.OnSceneClean += Clean;
    }

    private void OnDestroy()
    {
        GlobalEvents.OnSceneClean -= Clean;
    }
    void Update()
    {
        Vector3 directionVector = (moveDirection == Direction.Up) ? Vector3.up : Vector3.down;
        transform.Translate(directionVector * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (EnemyBulletTag.Length != 0 && other.CompareTag(EnemyBulletTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void Clean()
    {
        Destroy(gameObject);
    }
}
