using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Grandma : MonoBehaviour
{
    public StateofAngerType StateofAngerType;

    public Slider AngrySlider;
    public TextMeshProUGUI AngryText;
    public float angryDistance = 5f;
    public float AngryValue;
    public float AngryValuePerSecont = 0.2f;
    public float AngryValueFactor = 5;

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
        //SetAngerType(StateofAngerType.Happy);
    }
    private void LateUpdate()
    {
        if (GetFlyDistance() < angryDistance)
        {
            if (!IsThereBarrier())
            {
                AngryValue += (1 / GetFlyDistance()) * AngryValueFactor * Time.deltaTime;
            }
            else
            {
                if (AngryValue > 0)
                {
                    AngryValue -= AngryValuePerSecont * Time.deltaTime;
                }
                else
                {
                    AngryValue = 0;
                }

            }
        }
        else
        {
            if (AngryValue > 0)
            {
                AngryValue -= AngryValuePerSecont * Time.deltaTime;
            }
            else
            {
                AngryValue = 0;
            }
        }
        AngrySlider.value = AngryValue;
        switch (AngryValue)
        {
            case > 85:
                SetAngerType(StateofAngerType.Insane);
                break;
            case > 50:
                SetAngerType(StateofAngerType.Angry);
                break;
            case > 35:
                SetAngerType(StateofAngerType.Uneasy);
                break;
            default:
                SetAngerType(StateofAngerType.Happy);
                break;
        }
    }

    public void GoTransform(Transform goTransform)
    {
        NavMeshAgent.destination = goTransform.position;
    }

    public float GetDistance(Transform goTransform)
    {
        try
        {
            var temp = goTransform.position - transform.position;
            temp = new Vector3(temp.x, 0, temp.z);
            return temp.magnitude;
        }
        catch (System.Exception)
        {
        }
        return 0;
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
        if (stateofAngerType == StateofAngerType)
        {
            return;
        }
        AngryText.text = stateofAngerType.ToString();
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
        StateofAngerType = stateofAngerType;
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
