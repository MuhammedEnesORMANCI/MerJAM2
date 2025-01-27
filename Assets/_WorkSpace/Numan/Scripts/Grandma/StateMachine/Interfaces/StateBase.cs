using System.Collections;
using UnityEngine;

public abstract class StateBase
{
    public virtual Transform StateTransform => null;

    public abstract void EnterState(Grandma grandma);
    public abstract void UpdateState(Grandma grandma);
    public abstract void ExitState(Grandma grandma);

    public Vector2 StateTimeRandomize = new Vector2(10, 30);

    public bool Isbreak;
    public void AnimationStop(StateBase stateBase, Grandma grandma, float time)
    {
        GameManager.Instance.StartCoroutine(TimerEnumator(stateBase, grandma, time));
    }
    public IEnumerator TimerEnumator(StateBase stateBase, Grandma grandma, float time)
    {
        yield return new WaitForSeconds(time);
        if (Isbreak) { yield break; }
        WalkingState walkingState = new WalkingState();
        walkingState.NextState = grandma.GrandmaStateController.GetRandomState(stateBase);
        grandma.GrandmaStateController.ChangeState(walkingState);
    }

    public float GetRandomTime()
    {
        return Random.Range(StateTimeRandomize.x, StateTimeRandomize.y);
    }
}
