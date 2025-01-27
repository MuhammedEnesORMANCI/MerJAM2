using UnityEngine;

public class TargetFlyState : StateBase
{

    public override Transform StateTransform => GameManager.Instance.SleepingTransform;

    public override void EnterState(Grandma grandma)
    {
        grandma.Animator.Play(GrandmaAnimations.IS_WALKING);

        var t = GetRandomTime();
        AnimationStop(this, grandma, t);
        Debug.Log("SinekTakipEdiliyor");
    }
    public override void ExitState(Grandma grandma)
    {
        Debug.Log("TakipBitti Kurtuldun");
    }

    public override void UpdateState(Grandma grandma)
    {
        if (grandma.GetDistance(GameManager.Instance.Fly.transform) > 1f)
        {
            grandma.GoTransform(GameManager.Instance.Fly.transform);
        }
        else
        {
            if (!grandma.IsThereBarrier())
            {
                GameManager.Instance.HitSwatter();
                Debug.Log("Yakalandinnnnnn");
            }
            else
            {
                Debug.Log("Arada Duvar Var");
            }

        }
    }
}
