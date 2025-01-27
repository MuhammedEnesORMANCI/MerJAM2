using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 10f;
    public float moveYSpeed = 1f;
    public float smoothValue = 10f;
    public Rigidbody rb;
    public Transform playerBody;
    public Transform playerCamera;

    public Animator Animator;

    public static bool acabilirmi;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            Vector3 he = (playerBody.transform.position - playerCamera.transform.position).normalized;
            playerBody.transform.forward = Vector3.Lerp(playerBody.transform.forward, he, smoothValue * Time.deltaTime);

            playerBody.transform.rotation = Quaternion.Euler(0, playerBody.transform.rotation.eulerAngles.y, 0);
        }
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveUpward = 0;


        if (Input.GetKey(KeyCode.LeftShift)) moveUpward = 1;
        if (Input.GetKey(KeyCode.LeftControl)) moveUpward = -1;


        Vector3 moveDirection = (playerBody.forward * moveVertical * moveSpeed) +
                                (playerBody.right * moveHorizontal * (moveSpeed / 2)) +
                                (Vector3.up * moveUpward * moveYSpeed);


        rb.velocity = moveDirection;

        Animator.SetInteger("RotX", (int)moveHorizontal);
        Animator.SetInteger("RotY", (int)moveVertical);
    }
}
