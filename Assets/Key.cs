using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool isOpen;
    public Door door;
    private void OnTriggerEnter(Collider other)
    {
        if (isOpen)
        {
            door.OpenInfinity();
            Destroy(gameObject);
        }
    }
}
