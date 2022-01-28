using UnityEngine;

[CreateAssetMenu]
public class EatState : State
{
    public float RestoreEat = 0.6f;
    public State NoApplesState;

    Transform targetApple;

    public override void Init()
    {
        var apples = GameObject.FindGameObjectsWithTag("Apple");

        if (apples.Length == 0)
        {
            enemy.SetState(NoApplesState);
            return;
        }

        targetApple = apples[Random.Range(0, apples.Length)].transform;
    }

    public override void Run()
    {
        if (isFinished)
            return;

        MoveToApple();
    }

    public void MoveToApple()
    {
        var distance = (targetApple.position - enemy.transform.position).magnitude;

        if (distance > 1f)
        {
            enemy.MoveTo(targetApple.position);
        }
        else
        {
            targetApple.gameObject.SetActive(false);
            enemy.Eat += RestoreEat;
            isFinished = true;
        }
    }
}