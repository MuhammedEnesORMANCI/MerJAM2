using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaStateController : MonoBehaviour
{

    public StateBase currentState;

    private Grandma Grandma;

    private List<Type> StateBases = new List<Type>()
    {
        typeof(SittingState),
        typeof(SleepingState),
        typeof(EatingState),
    };

    private void Awake()
    {
        Grandma = GetComponent<Grandma>();
    }
    private void Start()
    {
        var s = new WalkingState();
        s.NextState = new EatingState();
        ChangeState(s);
    }
    private void Update()
    {
        currentState?.UpdateState(Grandma);
    }
    public void ChangeState(StateBase state)
    {
        currentState?.ExitState(Grandma);
        if (currentState is not null) { currentState.Isbreak = true; }
        currentState = state;
        currentState.EnterState(Grandma);
    }

    public StateBase GetRandomState(StateBase stateBase = null)
    {
        List<Type> list = new List<Type>(StateBases);
        if (stateBase is not null)
        {
            foreach (var item in list)
            {
                if (item == stateBase.GetType())
                {
                    list.Remove(item);
                    break;
                }
            }
        }


        int rnd = UnityEngine.Random.Range(0, list.Count);
        return (StateBase)Activator.CreateInstance(list[rnd]);
    }
}
