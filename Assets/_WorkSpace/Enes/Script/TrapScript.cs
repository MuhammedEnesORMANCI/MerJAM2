using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            var direction = other.transform.position - transform.position;

            other.GetComponent<Rigidbody>().AddForce(1000 * -direction.normalized, ForceMode.Acceleration);
        }



    }


}
