using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        //verticalInput = Input.GetAxisRaw("Vertical");
        verticalInput = Input.GetAxis("Vertical");
        //Debug.Log(verticalInput);
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed
            * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed
            * verticalInput * Time.deltaTime);
    }
}
