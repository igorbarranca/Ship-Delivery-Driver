using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float rotateSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        MoveCircular();
    }

    void MoveCircular()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
