using UnityEngine;

public class SittingState : StateBase
{
    public override Transform StateTransform => GameManager.Instance.SittingTransform;

    public override void EnterState(Grandma grandma)
    {
        grandma.Animator.Play(GrandmaAnimations.SITTING);

        var t = GetRandomTime();
        AnimationStop(this, grandma, t);
        Debug.Log("Oturuyor");
    }
    public override void ExitState(Grandma grandma)
    {
        Debug.Log("OturmaBitti");
    }

    public override void UpdateState(Grandma grandma)
    {
        if (grandma.IsWalking)
        {
            grandma.GrandmaStateController.ChangeState(new WalkingState());
        }
    }


}
