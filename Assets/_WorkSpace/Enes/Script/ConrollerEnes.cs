using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConrollerEnes : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    void Start()
    {

    }


    float x;
    float y;

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(x * 5, 0, y * 5);

    }
}
