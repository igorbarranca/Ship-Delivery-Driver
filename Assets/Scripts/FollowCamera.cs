using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform playerPos;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerPos.position + new Vector3(0f, 0f, -10f);
    }
}
