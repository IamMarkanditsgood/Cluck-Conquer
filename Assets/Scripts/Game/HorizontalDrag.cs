using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDrag  : MonoBehaviour
{
    [Header("Drag Limits")]
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;

    [Header("Sensitivity")]
    [SerializeField] private float dragSpeed = 0.01f;

    private Camera mainCamera;
    private Vector3 lastPointerPosition;
    private bool isDragging;

    public bool isActive;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!isActive) return;

#if UNITY_EDITOR
        HandleMouseDrag();
#else
        HandleTouchDrag();
#endif
    }

    private void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPointerPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentPointerPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            float deltaX = currentPointerPosition.x - lastPointerPosition.x;

            MoveHorizontally(deltaX);
            lastPointerPosition = currentPointerPosition;
        }
    }

    private void HandleTouchDrag()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        Vector3 touchWorldPos = mainCamera.ScreenToWorldPoint(touch.position);

        if (touch.phase == TouchPhase.Began)
        {
            lastPointerPosition = touchWorldPos;
            isDragging = true;
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            isDragging = false;
        }

        if (isDragging && touch.phase == TouchPhase.Moved)
        {
            float deltaX = touchWorldPos.x - lastPointerPosition.x;

            MoveHorizontally(deltaX);
            lastPointerPosition = touchWorldPos;
        }
    }

    private void MoveHorizontally(float deltaX)
    {
        Vector3 newPosition = transform.position;
        newPosition.x += deltaX * dragSpeed;

        // ќбмежуЇмо рух у межах
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }
}
