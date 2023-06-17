using System;
using UnityEngine;

/// <summary>
/// This is base state script implementation.
/// StateMachine uses these virtual methods to call state when it needs to prepare itself for operating, updating or even being destroyed.
/// </summary>
[Serializable]
public abstract class BaseState
{
    // Reference to our state machine.
    [HideInInspector] public StateMachine owner;


    /// <summary>
    /// Method called to prepare state to operate - same as Unity's Start()
    /// </summary>
    internal virtual void PrepareState()
    {
        // Debug.Log($"{GetType()}: PrepareState");
        owner.OnPrepareState?.Invoke(this);
    }

    /// <summary>
    /// Method called to update state on every frame - same as Unity's Update()
    /// </summary>
    public virtual void UpdateState() { }

    /// <summary>
    /// Method called to destroy state - same as Unity's OnDestroy() but here it might be important!
    /// </summary>
    public virtual void DestroyState()
    {
        owner.OnDestroyState?.Invoke(this);
        // Debug.Log($"{GetType()}: DestroyState");
    }
}