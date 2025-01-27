using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform DoorTransform;


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
        animator.Play("Close");
        GameManager.Instance.CloseDoorSound();
    }
}
