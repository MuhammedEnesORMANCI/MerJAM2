using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinekKovar : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] float DiedDirection;
    Vector3 direction;
    float AnlikMesafe;


    // Update is called once per frame
    void Update()
    {
        direction = Target.transform.position - transform.position;

        AnlikMesafe = Vector3.Distance(transform.position, Target.transform.position);

        if (AnlikMesafe * 2 < DiedDirection)
        {

            Debug.DrawLine(transform.position, Target.transform.position);

        }



        if (AnlikMesafe < DiedDirection)
        {
            Died();
        }

    }
    void Died()
    {
        //ölüm vs
    }
}
