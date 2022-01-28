using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] private int _health = 20;
    public Sprite front;
    public Sprite left;
    public Sprite right;
    public Sprite back;

    public float speed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 movement;

    public Joystick joystick;

    public GameObject bomb;


    private void OnEnable()
    {
        GameEvents.OnHealthChange += ApplyDamage;
    }

    private void OnDisable()
    {
        GameEvents.OnHealthChange -= ApplyDamage;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    }


    public void Bomb()
    {
        Instantiate(bomb, transform.position, Quaternion.identity);
    }


    public void ApplyDamage(int damage)
    {
        _health -= damage;
    }


    private void FixedUpdate()
    {
        if (joystick.Horizontal > 0)
        {
            sprite.sprite = right;
        }
        if (joystick.Horizontal < 0)
        {
            sprite.sprite = left;
        }
        if (joystick.Vertical > 0)
        {
            sprite.sprite = back;
        }
        if (joystick.Vertical < 0)
        {
            sprite.sprite = front;
        }

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
