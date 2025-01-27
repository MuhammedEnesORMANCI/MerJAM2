using UnityEngine;

public class SleepingState : StateBase
{
    public override Transform StateTransform => GameManager.Instance.SleepingTransform;

    public override void EnterState(Grandma grandma)
    {
        grandma.Animator.Play(GrandmaAnimations.SLEEPING);

        var t = GetRandomTime();
        AnimationStop(this, grandma, t);
        Debug.Log("Uyuyor");
    }
    public override void ExitState(Grandma grandma)
    {
        Debug.Log("UyumaBitti");
    }

    public override void UpdateState(Grandma grandma)
    {
        if (grandma.IsWalking)
        {
            grandma.GrandmaStateController.ChangeState(new WalkingState());
        }
    }
}
