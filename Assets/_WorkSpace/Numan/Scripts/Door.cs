using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform DoorTransform;

    public Collider collider;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        //Open(true);
    }

    public void Open(bool isFront)
    {
        if (!collider.enabled)
        {
            return;
        }
        if (isFront)
        {
            animator.Play("Open");
        }
        else
        {
            animator.Play("OpenReverse");
        }
        GameManager.Instance.OpenDoorSound();
    }
    public void Close()
    {
        if (!collider.enabled)
        {
            return;
        }
        animator.Play("Close");
        GameManager.Instance.CloseDoorSound();
    }

    public void OpenInfinity()
    {
        DoorTransform.rotation = Quaternion.Euler(DoorTransform.rotation.eulerAngles.x, DoorTransform.rotation.eulerAngles.y, 135);
        collider.enabled = false;
    }
}
