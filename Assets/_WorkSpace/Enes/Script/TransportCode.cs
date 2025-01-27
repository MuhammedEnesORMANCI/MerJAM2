using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.Mathematics;
using UnityEngine;

public class TransportCode : MonoBehaviour
{
    [SerializeField] Transform tr;

    [SerializeField] LayerMask TransportLayer;

    [SerializeField] bool DoluMu;

    [SerializeField] GameObject gameObjects;





    // Update is called once per frame
    void Update()
    {
        Birak();

    }


    private void OnTriggerStay(Collider other)
    {

        if (other.transform.tag == "Portable Object")
        {
            if (gameObjects == null || DoluMu == false)
            {
                gameObjects = other.gameObject;
            }



            al();


        }
        else if (DoluMu == false)
        {
            gameObjects = null;
        }

    }
    void al()
    {
        if (Input.GetKeyDown(KeyCode.E) && DoluMu == false)
        {


            gameObjects.GetComponent<Rigidbody>().isKinematic = true;

            gameObjects.transform.position = tr.position;

            gameObjects.GetComponent<CapsuleCollider>().isTrigger = true;

            gameObjects.transform.SetParent(tr);

            DoluMu = true;



        }
    }
    void Birak()
    {
        if (Input.GetKeyDown(KeyCode.R) && DoluMu == true)
        {

            DoluMu = false;

            gameObjects.transform.rotation = Quaternion.identity;
            gameObjects.transform.SetParent(null);

            gameObjects.GetComponent<CapsuleCollider>().isTrigger = false;
            gameObjects.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            gameObjects = null;

        }
    }

}
