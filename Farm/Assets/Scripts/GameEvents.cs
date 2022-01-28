using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void HealthChange(int damage);
    public static event HealthChange OnHealthChange;

    public static void HealthChangeMethod(int damage)
    {
        OnHealthChange?.Invoke(damage);
    }
}
