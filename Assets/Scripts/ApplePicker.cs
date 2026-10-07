using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ApplePicker : MonoBehaviour
{
    private const float RAY_DISTANCE = 10.0f;

    [SerializeField] private float pickInterbal;
    private float _pickTimer;

    private float pickTimer
    {
        get
        {
            return _pickTimer;
        }
        set
        {
            _pickTimer = value;
            onPickTimerChanged?.Invoke(PickProgress);
        }
    }

    public float PickProgress => pickTimer / pickInterbal;

    [SerializeField] private int pickDamage;
    [SerializeField] private float pickRadius;
    public float PickRadius => pickRadius;

    private Vector2 _mousePos;
    private Vector2 mousePos
    {
        get
        {
            return _mousePos;
        }
        set
        {
            _mousePos = value;
            onMousePosChanged?.Invoke(value);
        }
    }

    public static event Action<float> onPickTimerChanged;
    public static event Action<Vector2> onMousePosChanged;

    private void Start()
    {
        pickTimer = 0;
    }

    private void Update()
    {
        if (Mouse.current == null) return;

        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        pickTimer += Time.deltaTime;

        if (pickTimer >= pickInterbal)
            Pick();
    }

    private void Pick()
    {
        //Debug.Log("ûŠn");

        pickTimer = 0;

        Collider2D[] targets = Physics2D.OverlapCircleAll(mousePos, pickRadius);

        if (targets != null && targets.Length != 0)
        {
            //Debug.Log("ƒŠƒ“ƒS‚ğŒŸ’mI");

            foreach (var target in targets)
            {
                if(target.TryGetComponent(out Apple apple))
                    apple.TakeDamage(pickDamage);
            }
        }
    }
}