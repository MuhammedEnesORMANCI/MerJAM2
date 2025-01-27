using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvScript : MonoBehaviour
{
    [SerializeField] GameObject Target;

    [SerializeField] GameObject CekimNoktasi;

    [SerializeField] int MaxAngel;

    [SerializeField] float MaxDistance;

    [SerializeField] float MaxSpeed;
    [SerializeField] float MinMesafe;

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
        direction = Target.transform.position - CekimNoktasi.transform.position;

        NDirection = direction.normalized;

        AnlikMesafe = Vector3.Distance(CekimNoktasi.transform.position, Target.transform.position);

        //Debug.Log(AnlikMesafe);

        Debug.DrawRay(CekimNoktasi.transform.position, -CekimNoktasi.transform.forward * 10, Color.red);

        Debug.DrawLine(CekimNoktasi.transform.position, Target.transform.position);

        Angel = Vector3.Angle(-CekimNoktasi.transform.forward, direction);



        //bool isOpen = Physics.Linecast(transform.position + -Vector3.forward, Target.transform.position + Vector3.forward, ObjectLayer);// bu arasına eşya koyarız belki diye
        // Bu önünde nesne olursa diye var



        if (true)//isopen
        {
            if (Angel < MaxAngel && AnlikMesafe < MaxDistance && AnlikMesafe > MinMesafe)
            {

                Target.GetComponent<Rigidbody>().AddForce(MaxSpeed * NDirection * 1 / direction.z, ForceMode.Acceleration);


            }


        }

    }
}
