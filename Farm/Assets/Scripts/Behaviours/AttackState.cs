using UnityEngine;

[CreateAssetMenu]
public class AttackState : State
{
    private Vector3 attackOffset;
    [SerializeField] private LayerMask attackMask;

    private readonly bool isAttackStarted;

    [SerializeField] private float speed = 1f;
    private Transform targetPlayer;
    private float minDistance = 4f;


    public override void Init()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Pig").transform;
    }

    public override void Run()
    {
        if (isFinished)
            return;

        if (!isAttackStarted)
            Follow();
        else 
            Attack();

        if (IsTakenDamage(28))
        {
            GetDamage();
        }
    }

    private void Follow()
    {
        if (Vector2.Distance(enemy.transform.position, targetPlayer.position) < minDistance)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
    }

    private void Attack()
    {
         
    }

    private void GetDamage()
    {
        Debug.Log("GetDamage");
        isFinished = true;
    }

    private bool IsTakenDamage(int value)
    {
        return enemy.currentHealth <= value;
    }
}
