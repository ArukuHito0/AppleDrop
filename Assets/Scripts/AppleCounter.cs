using System;
using TMPro;
using UnityEngine;

public class AppleCounter : MonoBehaviour
{
    private int appleCount = 0;

    [SerializeField] private TextMeshProUGUI appleCountText;

    private void OnEnable()
    {
        Basket.onAppleCollected += AddAppleCount;
    }

    private void OnDisable()
    {
        Basket.onAppleCollected -= AddAppleCount;
    }

    private void Start()
    {
        appleCountText.text = $"{appleCount} apple";
    }

    private void AddAppleCount(int cnt)
    {
        appleCount += cnt;
        appleCountText.text = $"{appleCount} apple";
    }
}
