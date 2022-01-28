using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RandomMoveState : State
{
    public float MaxDistance = 5f;
    Vector3 randomPosition;

    public override void Init()
    {
        var randomed = new Vector3(Random.Range(-MaxDistance, MaxDistance), 0f, 0f);
        randomPosition = enemy.transform.position + randomed;
    }

    public override void Run()
    {
        var distance = (randomPosition - enemy.transform.position).magnitude;

        if (distance > 0.5f)
            enemy.MoveTo(randomPosition);
        else
            isFinished = true;
    }
}
