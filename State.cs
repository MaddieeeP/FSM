using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public abstract class State<EState> where EState : Enum
{
    protected StateMachine<EState> _stateMachine;

    public virtual void EnterState() { }

    public virtual void Update() { }

    public virtual void ExitState() { }

    public abstract EState GetNextState();

    public virtual void OnTriggerEnter(Collider other) { }

    public virtual void OnTriggerStay(Collider other) { }

    public virtual void OnTriggerExit(Collider other) { }

    public virtual void OnCollisionEnter(Collision other) { }

    public virtual void OnCollisionStay(Collision other) { }

    public virtual void OnCollisionExit(Collision other) { }
}
