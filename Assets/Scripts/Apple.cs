using System;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public enum State
    {
        Normal,
        Harvested,
    }

    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    [SerializeField] private float defaultGravityScale = 0.7f;

    private float bonusMultiplier = 0;  // ‰ñŽûŽž‚É”{—¦‚É‰ÁŽZ‚·‚é’l
    public float BonusMultiplier => bonusMultiplier;

    public static event Action onAppleHarvested;
    public static List<Apple> appleList = new List<Apple>();

    public void Initialize(State state)
    {
        switch (state)
        {
            case State.Normal:
                appleList.Add(this);
                rb.gravityScale = 0.0f;
                circleCollider.isTrigger = true;
                break;
            case State.Harvested:
                Harvest();
                break;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void Harvest()
    {
        rb.gravityScale = defaultGravityScale;
        circleCollider.isTrigger = false;

        appleList.Remove(this);

        onAppleHarvested?.Invoke();
    }

    public void AddBonusMultiplier(float amount)
    {
        bonusMultiplier += amount;
    }

    public static bool IsEmpty()
    {
        return appleList.Count == 0;
    }
}
