using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    [SerializeField] GameObject Target;

    [SerializeField] GameObject FaniktirmeNoktai;

    [SerializeField] int MaxAngel;

    [SerializeField] float MaxDistance;

    [SerializeField] float MaxSpeed;

    [SerializeField] LayerMask ObjectLayer;
    [SerializeField] Vector3 vec3Pos;

    [SerializeField] float AnlikMesafe;

    [SerializeField] float Angel;

    [SerializeField] float YMaxAngelWt;
    [SerializeField] float YMinAngelWt;


    [SerializeField] float XMaxAngelWt;
    [SerializeField] float XMinAngelWt;

    public GameObject Engel;
    public GameObject fAN;

    Vector3 direction;

    Vector3 NDirection;

    int a;
    void Update()
    {
        

        FanMeka();



    }

    public void FanMeka()
    {

        /*
        direction = Target.transform.position - FaniktirmeNoktai.transform.position;

        NDirection = direction.normalized;

        AnlikMesafe = Vector3.Distance(FaniktirmeNoktai.transform.position, Target.transform.position);



        Debug.DrawRay(FaniktirmeNoktai.transform.position, -FaniktirmeNoktai.transform.forward * 4, Color.red);

        Debug.DrawLine(FaniktirmeNoktai.transform.position, Target.transform.position);

        Angel = Vector3.Angle(-FaniktirmeNoktai.transform.forward, direction);   // beli bi hzı ulaşinca m sınırlask acaba



        bool isOpen = Physics.Linecast(FaniktirmeNoktai.transform.position + -Vector3.forward, Target.transform.position + Vector3.forward, ObjectLayer);// bu arasına eşya koyarız belki diye
                                                                                                                                                         // Bu önünde nesne olursa diye var

        vec3Pos = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);





        if (isOpen)
        {
            if (Angel < MaxAngel && AnlikMesafe < MaxDistance)
            {

                if ((transform.rotation.y > YMinAngelWt || transform.rotation.y < YMaxAngelWt) && (transform.position.x > XMinAngelWt || transform.position.x < XMaxAngelWt))// Fan bizi takip edecekse bunu kullaın
                {
                    //transform.LookAt(vec3Pos);
                }

                // Target.GetComponent<Rigidbody>().velocity = MaxSpeed * transform.forward * 10 / direction.z;// bu başka artanatif

                //Target.GetComponent<Rigidbody>().velocity = MaxSpeed * NDirection * 10 / direction.z;


                Target.GetComponent<Rigidbody>().AddForce(MaxSpeed * NDirection * 4 / direction.z, ForceMode.Acceleration);


            }


        }
        */

    }
}
