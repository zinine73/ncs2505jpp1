using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horsePower = 20.0f;
    [SerializeField] float turnSpeed = 45.0f;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    float horizontalInput;
    float verticalInput;
    Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {
        // 키값 입력
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //if (IsOnGround())
        {
            // 앞뒤 이동
            // transform.Translate(Vector3.forward *
            //     Time.deltaTime * speed *
            //     forwardInput);
            playerRb.AddRelativeForce(Vector3.forward
                * verticalInput * horsePower);
            // 좌우 이동
            transform.Rotate(Vector3.up,
                turnSpeed * horizontalInput *
                Time.deltaTime);

            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + "mph");
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }
    
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (var wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        return (wheelsOnGround == 4) ? true : false;
    }
}
