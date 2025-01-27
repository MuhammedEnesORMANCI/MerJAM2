using UnityEngine;

public class EatingState : StateBase
{
    public override Transform StateTransform => GameManager.Instance.EatingTransform;

    public override void EnterState(Grandma grandma)
    {
        grandma.Animator.Play(GrandmaAnimations.EATING);

        var t = GetRandomTime();
        AnimationStop(this, grandma, t);
        Debug.Log("YemekYiyor");
    }
    public override void ExitState(Grandma grandma)
    {
        Debug.Log("YemekBitti");
    }

    public override void UpdateState(Grandma grandma)
    {
        if (grandma.IsWalking)
        {
            grandma.GrandmaStateController.ChangeState(new WalkingState());
        }
    }
}
