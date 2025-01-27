using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform playerCamera;
    public float sensitivityX = 5f;
    public float sensitivityY = 5f;
    public float minY = -30f;
    public float maxY = 80f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {

        rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        rotationY += Input.GetAxis("Mouse X") * sensitivityX;


        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        player.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
