using UnityEngine;

public class Brinko : MonoBehaviour
{
    [SerializeField] private float bounceBonusMultiplier = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Apple apple))
        {
            apple.AddBonusMultiplier(bounceBonusMultiplier);
        }
    }
}
