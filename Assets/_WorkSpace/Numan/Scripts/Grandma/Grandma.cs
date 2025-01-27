using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grandma : MonoBehaviour
{
    public StateofAngerType StateofAngerType;

    public bool IsWalking;

    public LayerMask LayerMask;

    [HideInInspector] public NavMeshAgent NavMeshAgent;
    [HideInInspector] public Animator Animator;
    [HideInInspector] public GrandmaStateController GrandmaStateController;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        GrandmaStateController = GetComponent<GrandmaStateController>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        SetAngerType(StateofAngerType);
    }
    private void Update()
    {

    }
    private void LateUpdate()
    {
    }

    public void GoTransform(Transform goTransform)
    {
        NavMeshAgent.destination = goTransform.position;
    }

    public float GetDistance(Transform goTransform)
    {
        var temp = goTransform.position - transform.position;
        temp = new Vector3(temp.x, 0, temp.z);
        return temp.magnitude;
    }

    public float GetFlyDistance()
    {
        var temp = GameManager.Instance.Fly.transform.position - transform.position;
        temp = new Vector3(temp.x, 0, temp.z);
        return temp.magnitude;
    }

    public bool IsThereBarrier()
    {
        RaycastHit hit;
        Vector3 direction = (GameManager.Instance.Fly.transform.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, LayerMask))
        {
            Debug.Log(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag == "Fly")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    public void SetAngerType(StateofAngerType stateofAngerType)
    {
        switch (stateofAngerType)
        {
            case StateofAngerType.Insane:
                var targetFlyState = new TargetFlyState();
                targetFlyState.StateTimeRandomize = new Vector2(20, 40);
                GrandmaStateController.ChangeState(targetFlyState);
                break;
            case StateofAngerType.Angry:
                var targetFlyState1 = new TargetFlyState();
                targetFlyState1.StateTimeRandomize = new Vector2(10, 20);
                GrandmaStateController.ChangeState(targetFlyState1);
                break;
            case StateofAngerType.Uneasy:
                var t3 = new WalkingState();
                t3.NextState = GrandmaStateController.GetRandomState();
                GrandmaStateController.ChangeState(t3);
                break;
            case StateofAngerType.Happy:
                var t4 = new WalkingState();
                t4.NextState = GrandmaStateController.GetRandomState();
                GrandmaStateController.ChangeState(t4);
                break;

        }



    }
}
public class GrandmaAnimations
{
    public const string IS_WALKING = "IsWalking";
    public const string IS_IDLE = "IsIdle";
    public const string SITTING = "Sitting";
    public const string SLEEPING = "Sleeping";
    public const string EATING = "Sleeping";

    public const string HIT_SWATTER = "HitSwatter";
}
