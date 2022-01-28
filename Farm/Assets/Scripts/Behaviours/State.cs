using UnityEngine;

public abstract class State : ScriptableObject
{
    public bool isFinished { get; protected set; }
    [HideInInspector] public Enemy enemy;

    public virtual void Init() { }
    public abstract void Run();
}
