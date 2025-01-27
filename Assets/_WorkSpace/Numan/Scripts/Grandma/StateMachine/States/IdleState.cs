using UnityEngine;

public class IdleState : StateBase
{
    public override void EnterState(Grandma grandma)
    {
        grandma.Animator.SetBool(GrandmaAnimations.IS_IDLE, true);

        var t = GetRandomTime();
        AnimationStop(this, grandma, t);
        Debug.Log("Duruyor");
    }

    public override void ExitState(Grandma grandma)
    {
        grandma.Animator.SetBool(GrandmaAnimations.IS_IDLE, false);
        Debug.Log("Durmabitti");
    }

    public override void UpdateState(Grandma grandma)
    {
        if (grandma.IsWalking)
        {
            grandma.GrandmaStateController.ChangeState(new WalkingState());
        }
    }
}