using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvScript : MonoBehaviour
{
    [SerializeField] GameObject Target;

    [SerializeField] int MaxAngel;

    [SerializeField] float MaxDistance;

    [SerializeField] float MaxSpeed;

    [SerializeField] LayerMask ObjectLayer;
    [SerializeField] Vector3 vec3Pos;

    [SerializeField] float AnlikMesafe;

    [SerializeField] float Angel;


    Vector3 direction;

    Vector3 NDirection;

    void Update()
    {

        TvMeka();

    }

    public void TvMeka()
    {
        direction = Target.transform.position - transform.position;

        NDirection = -direction.normalized;

        AnlikMesafe = Vector3.Distance(transform.position, Target.transform.position);

        //Debug.Log(AnlikMesafe);

        Debug.DrawRay(transform.position, transform.forward * 4, Color.red);

        Debug.DrawLine(transform.position, Target.transform.position);

        Angel = Vector3.Angle(transform.forward, direction);



        bool isOpen = Physics.Linecast(transform.position + Vector3.forward, Target.transform.position + Vector3.forward, ObjectLayer);// bu arasına eşya koyarız belki diye
        // Bu önünde nesne olursa diye var



        if (isOpen)
        {
            if (Angel < MaxAngel && AnlikMesafe < MaxDistance)
            {

                Target.GetComponent<Rigidbody>().AddForce(MaxSpeed * NDirection * 4 / direction.z, ForceMode.Acceleration);


            }


        }

    }
}
