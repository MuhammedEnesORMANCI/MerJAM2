using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 10f;
    public Rigidbody rb;
    public Transform playerBody;
    public Transform playerCamera;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        playerBody.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveUpward = 0;


        if (Input.GetKey(KeyCode.LeftShift)) moveUpward = 1;
        if (Input.GetKey(KeyCode.LeftControl)) moveUpward = -1;


        Vector3 moveDirection = (playerBody.forward * moveVertical) +
                                (playerBody.right * moveHorizontal) +
                                (Vector3.up * moveUpward);


        rb.velocity = moveDirection * moveSpeed;
    }
}
