using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] float turnSpeed = 45.0f;
    float horizontalInput;
    float forwardInput;
    void FixedUpdate()
    {
        // 키값 입력
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // 앞뒤 이동
        transform.Translate(Vector3.forward *
            Time.deltaTime * speed *
            forwardInput);
        // 좌우 이동
        transform.Rotate(Vector3.up,
            turnSpeed * horizontalInput *
            Time.deltaTime);
    }
}
