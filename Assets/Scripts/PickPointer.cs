using UnityEngine;
using UnityEngine.UI;

public class PickPointer : MonoBehaviour
{
    private RectTransform rTransform;

    [SerializeField] private Image pickGauge;

    private void OnEnable()
    {
        ApplePicker.onPickTimerChanged += PickGaugeFill;
        ApplePicker.onMousePosChanged += MousePosTrack;
    }

    private void OnDisable()
    {
        ApplePicker.onPickTimerChanged -= PickGaugeFill;
        ApplePicker.onMousePosChanged -= MousePosTrack;
    }

    private void Awake()
    {
        rTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        ApplePicker picker = GameObject.Find("ApplePicker").GetComponent<ApplePicker>();
        rTransform.localScale = new Vector3(picker.PickRadius, picker.PickRadius);
    }

    private void PickGaugeFill(float progress)
    {
        pickGauge.rectTransform.localScale = new Vector3(progress, progress);
    }

    private void MousePosTrack(Vector2 mousePos)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(mousePos);
        rTransform.position = screenPos;
    }
}
