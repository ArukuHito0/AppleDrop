using UnityEngine;

public class Apple : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    [SerializeField] private float defaultGravityScale = 0.7f;

    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.gravityScale = 0.0f;
        circleCollider.isTrigger = true;

        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0) Harvest();
    }

    private void Harvest()
    {
        rb.gravityScale = defaultGravityScale;
        circleCollider.isTrigger = false;
    }
}
