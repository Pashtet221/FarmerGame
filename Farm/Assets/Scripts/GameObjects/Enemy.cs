using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] public int maxHealth => currentHealth;
    [SerializeField] public int currentHealth;

    [SerializeField] private Transform targetPlayer;

    public HealthBar healthBar;

    [Header("AttackParametres")]
    [SerializeField] private int _attackDamage = 5;
    [SerializeField] private float attackArea = 4;

    [Header("Initial Parameters")]
    public float Eat = 1f;
    public float Energy = 1f;

    public State StartState;
    public State EatState;
    public State EnergyState;
    public State AttackState;
    public State DogState;
    public State RandomMoveState;

    [Header("Actual state")]
    public State currentState;

    float eatEndTime = 15f;
    float energyEndTime = 25f;


    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

        SetState(StartState);
    }

    private void Update()
    {
        Eat -= Time.deltaTime / eatEndTime;
        Energy -= Time.deltaTime / energyEndTime;

        if (!currentState.isFinished)
        {
            currentState.Run();
        }
        else
        {
            if (Eat <= 0.4f)
                SetState(EatState);
            else if (Energy <= 0.4f)
                SetState(EnergyState);
            else if (currentHealth <= maxHealth / 2)
                SetState(DogState);
            else if (Vector2.Distance(transform.position, targetPlayer.position) < attackArea)
                    SetState(AttackState);
            else
                    SetState(RandomMoveState);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackArea);
    }

    public void SetState(State state)
    {
        currentState = Instantiate(state);
        currentState.enemy = this;
        currentState.Init();
    }

    public void MoveTo(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime);
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pig") && collision != null)
        {
            GameEvents.HealthChangeMethod(_attackDamage);
        }
    }
}
