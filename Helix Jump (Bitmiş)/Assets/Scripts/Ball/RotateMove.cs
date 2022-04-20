using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMove : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = -200f;

    private float moveX;

    private void Update()
    {
        moveX = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, moveX * rotateSpeed * Time.deltaTime, 0f);
        }
    }
}
