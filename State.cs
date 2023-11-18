using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<EState> where EState : Enum
{
    public EState key { get; private set; }

    public State(EState key)
    {
        key = key;
    }

    public abstract void EnterState();

    public abstract void Update();

    public abstract void ExitState();

    public abstract EState GetNextState();

    public virtual void OnTriggerEnter(Collider other) { }

    public virtual void OnTriggerStay(Collider other) { }

    public virtual void OnTriggerExit(Collider other) { }

    public virtual void OnCollisionEnter(Collider other) { }

    public virtual void OnCollisionStay(Collider other) { }

    public virtual void OnCollisionExit(Collider other) { }
}
