using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public bool IsFront;
    public Door Door;

    public void Open()
    {
        Door.Open(IsFront);
    }

    public void Close()
    {
        Door.Close();
    }
}
