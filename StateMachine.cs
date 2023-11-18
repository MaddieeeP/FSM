using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, State<EState>> states = new Dictionary<EState, State<EState>>();
    protected EState currentEState;
    public State<EState> currentState { get { return states[currentEState]; } }

    void Start()
    {
        
    }

    void Update()
    {
        EState key = currentState.GetNextState();
        if (key.Equals(currentEState))
        {
            currentState.Update();
        }
        else
        {
            currentState.ExitState();
            currentEState = key;
            currentState.EnterState();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }

    void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }

    void OnCollisionEnter(Collider other)
    {
        currentState.OnCollisionEnter(other);
    }

    void OnCollisionStay(Collider other)
    {
        currentState.OnCollisionStay(other);
    }

    void OnCollisionExit(Collider other)
    {
        currentState.OnCollisionExit(other);
    }
}
