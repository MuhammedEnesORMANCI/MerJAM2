using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diski : MonoBehaviour
{
    public FlyController flyController;
    public GameObject Info;

    public GameObject kapatilincakapatilcak;
    public GameObject kapatilincaAcilacak;

    private bool heh;

    private bool kapalimi;
    public void Beslen()
    {
        kapalimi = true;
        kapatilincakapatilcak.SetActive(false);
        kapatilincaAcilacak.SetActive(true);
        Key.isOpen = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && heh)
        {
            Beslen();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fly")
        {
            heh = true;
            Debug.Log("fsgfdgdhnjhfgds");
            Info.SetActive(true);
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
