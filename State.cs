using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public abstract class State<EState> where EState : Enum
{
    public abstract void EnterState();

    public abstract void Update();

    public abstract void ExitState();

    public abstract EState GetNextState();

    public virtual void OnTriggerEnter(Collider other) { }

    public virtual void OnTriggerStay(Collider other) { }

    public virtual void OnTriggerExit(Collider other) { }

    public virtual void OnCollisionEnter(Collision other) { }

    public virtual void OnCollisionStay(Collision other) { }

    public virtual void OnCollisionExit(Collision other) { }
}
