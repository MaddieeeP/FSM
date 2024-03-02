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

    public virtual void SetField<T>(string fieldName, T value) { }

    public void TransitionState(EState nextState, bool checkStateChange = false)
    {
        if (checkStateChange && _currentState.Equals(nextState))
        {
            return;
        }
        currentState.ExitState();
        _currentState = nextState;
        currentState.EnterState();
    }

    protected virtual void Start()
    {
        _currentState = _startState;
        currentState.EnterState();
    }

    protected virtual void Update()
    {
        currentState.Update();
    }

    protected virtual void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(other);
    }

    protected virtual void OnCollisionStay(Collision other)
    {
        currentState.OnCollisionStay(other);
    }

    protected virtual void OnCollisionExit(Collision other)
    {
        currentState.OnCollisionExit(other);
    }
}