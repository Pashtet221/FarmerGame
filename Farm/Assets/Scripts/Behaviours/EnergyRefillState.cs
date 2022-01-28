using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnergyRefillState : State
{
    Transform targetBed;

    Vector3 lastCharPos;

    bool isSleepStarted;
    float sleepTimeLeft = 7f;

    public override void Init()
    {
        targetBed = GameObject.FindGameObjectWithTag("Bed").transform;
    }

    public override void Run()
    {
        if (isFinished)
            return;

        if (!isSleepStarted)
            MoveToBad();
        else
            DoSleep();
    }

    private void MoveToBad()
    {
        var distance = (targetBed.position - enemy.transform.position).magnitude;

        if (distance > 1f)
        {
            enemy.MoveTo(targetBed.position);
        }
        else
        {
            lastCharPos = enemy.transform.position;
            enemy.transform.position = targetBed.position;

           // enemy.animator.Play("Sleep");
            isSleepStarted = true;
        }
    }

    private void DoSleep()
    {
        sleepTimeLeft -= Time.deltaTime;

        if (sleepTimeLeft > 0f)
            return;

       // enemy.animator.Play("EndSleep");
        enemy.transform.position = lastCharPos;
        enemy.Energy = 1f;
        isFinished = true;
    }
}
