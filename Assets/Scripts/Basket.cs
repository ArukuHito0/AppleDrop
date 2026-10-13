using System;
using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private TextMeshPro multiplierText;
    [SerializeField] private int multiplier = 1;

    public static event Action<int> onAppleCollected;

    private void Start()
    {
        MultiplierTextUpdate();
    }

    public void MultiplierTextUpdate()
    {
        multiplierText.text = $"x{multiplier}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("“–‚½‚Á‚½");

        if (collision.gameObject.TryGetComponent(out Apple apple))
        {
            //Debug.Log("ƒŠƒ“ƒS‚ðŽæ“¾");

            var result = Mathf.FloorToInt(apple.BonusMultiplier + multiplier);

            Debug.Log($"‰ñŽû”{—¦: {result}");

            onAppleCollected?.Invoke(result);
            Destroy(apple.gameObject);
        }
    }
}
