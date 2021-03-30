using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //arrow movement speed
    public float ArrowmoveSpeed = 5f;

    //mouse speed
    public float mouseSpeed = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        //locking the player's cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (PlayerManager.instance.getPlayerStatus() == true)
        {
            //making the movements input by the player constantly update
            float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

            //using the inputs
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            yRotation += mouseX;
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}