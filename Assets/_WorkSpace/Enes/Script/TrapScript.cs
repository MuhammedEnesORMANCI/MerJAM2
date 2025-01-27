using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        var direction = other.transform.position - transform.position;

        other.GetComponent<Rigidbody>().AddForce(1000 * -direction.normalized, ForceMode.Acceleration);


    }


}
