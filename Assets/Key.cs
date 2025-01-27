using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Info;

    public GameObject kapatilincakapatilcak;

    private bool heh;

    private bool kapalimi;

    public static bool isOpen;
    public Door door;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && heh)
        {
            Ac();
        }
    }

    private void Ac()
    {
        door.OpenInfinity();
        Destroy(gameObject);
        kapalimi = true;
        kapatilincakapatilcak.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Fly")
        {
            if (isOpen)
            {
                heh = true;
                Debug.Log("fsgfdgdhnjhfgds");
                Info.SetActive(true);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fly")
        {
            heh = false;
            Info.SetActive(false);
        }
    }
}
