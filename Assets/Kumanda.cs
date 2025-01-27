using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kumanda : MonoBehaviour
{
    [SerializeField] FanScript fanScript;

    public GameObject Info;

    public GameObject kapatilincakapatilcak;

    private bool heh;

    private bool kapalimi;
    public void Kapat()
    {
        fanScript.Engel.SetActive(false);
        kapalimi = true;
        kapatilincakapatilcak.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && heh)
        {
            Kapat();
        }
        if (!kapalimi)
        {
            fanScript.fAN.transform.Rotate(0, 0, 600 * Time.deltaTime);
        }
        else
        {

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
