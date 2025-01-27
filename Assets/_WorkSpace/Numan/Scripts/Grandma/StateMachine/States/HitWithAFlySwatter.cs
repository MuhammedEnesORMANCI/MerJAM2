using UnityEngine;

public class HitWithAFlySwatter : StateBase
{
    //public override Transform StateTransform => GameManager.Instance.SleepingTransform;

    public override void EnterState(Grandma grandma)
    {
        grandma.Animator.Play(GrandmaAnimations.HIT_SWATTER);

        GameManager.Instance.HitSwatter();
        Debug.Log("Sinek Sineklikle Vuruldu");
    }
    public override void ExitState(Grandma grandma)
    {
        Debug.Log("Bitti(HitWithAFlySwatter)");
    }

    public override void UpdateState(Grandma grandma)
    {
    }
}
