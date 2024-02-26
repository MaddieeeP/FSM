using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected abstract Dictionary<EState, State<EState>> states { get; }
    [SerializeField] protected EState _startState;
    protected EState _currentState;

    //getters and setters
    public State<EState> currentState { get { return states[_currentState]; } }

    public virtual T GetField<T>(string fieldName)
    {
        return default(T);
    }

    public virtual void SetField<T>(string fieldName, T value)
    {
        return;
    }

    protected void Start()
    {
        _currentState = _startState;
        currentState.EnterState();
    }

    protected void Update()
    {
        EState key = currentState.GetNextState();
        if (key.Equals(_currentState))
        {
            currentState.Update();
        }
        else
        {
            currentState.ExitState();
            _currentState = key;
            currentState.EnterState();
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    protected void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }

    protected void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }

    protected void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(other);
    }

    protected void OnCollisionStay(Collision other)
    {
        currentState.OnCollisionStay(other);
    }

    protected void OnCollisionExit(Collision other)
    {
        currentState.OnCollisionExit(other);
    }
}