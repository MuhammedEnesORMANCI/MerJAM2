using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaCollisionManager : MonoBehaviour
{
    public Grandma Grandma;

    private Door _tempDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (_tempDoor is not null) { return; }
        if (other.gameObject.TryGetComponent(out DoorCollider doorCollider))
        {
            doorCollider.Open();
            _tempDoor = doorCollider.Door;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Door door))
        {
            door.Close();
            _tempDoor = null;
        }
    }
}
