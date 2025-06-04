using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float speed = 5f;

    public enum Direction
    {
        Up,
        Down
    }

    [SerializeField] private Direction moveDirection = Direction.Up;

    void Update()
    {
        Vector3 directionVector = (moveDirection == Direction.Up) ? Vector3.up : Vector3.down;
        transform.Translate(directionVector * speed * Time.deltaTime);
    }
}
