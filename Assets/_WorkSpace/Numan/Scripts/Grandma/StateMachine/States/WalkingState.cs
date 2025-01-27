using UnityEngine;

public class WalkingState : StateBase
{
    public StateBase NextState;
    public override void EnterState(Grandma grandma)
    {
        grandma.Animator.SetBool(GrandmaAnimations.IS_WALKING, true);
        Debug.Log("Yuruyor");
    }

    public override void ExitState(Grandma grandma)
    {
        grandma.Animator.SetBool(GrandmaAnimations.IS_WALKING, false);
        Debug.Log("YurumeBiti");
    }

    public override void UpdateState(Grandma grandma)
    {
        if (grandma.GetDistance(NextState.StateTransform) > 0.2f)
        {
            grandma.GoTransform(NextState.StateTransform);
        }
        else
        {
            grandma.GrandmaStateController.ChangeState(NextState);
            Debug.Log("YurumeBiti");
        }

    }
}
