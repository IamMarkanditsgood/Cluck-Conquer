using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private float minSwipeDistance = 50f; // ̳������� ��������� ��� ��������� ������

    public GameObject page1; // ����� �������
    public GameObject page2; // ����� �������

    void Update()
    {
#if UNITY_EDITOR
        // ��� ���������� � �������� �����
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchEndPos = Input.mousePosition;
            DetectSwipe();
        }
#else
        // ��� �������� ��������
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;
                DetectSwipe();
            }
        }
#endif
    }

    private void DetectSwipe()
    {
        float swipeDistance = (touchEndPos - touchStartPos).magnitude;

        if (swipeDistance >= minSwipeDistance)
        {
            Vector2 direction = touchEndPos - touchStartPos;
            float x = direction.x;

            if (Mathf.Abs(x) > Mathf.Abs(direction.y))
            {
                if (x < 0)
                {
                    // ����� ���� � �������� ����� �������
                    ShowPage1();
                }
                else
                {
                    // ����� ������ � �������� ����� �������
                    ShowPage2();
                }
            }
        }
    }

    private void ShowPage1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }

    private void ShowPage2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
    }
}
