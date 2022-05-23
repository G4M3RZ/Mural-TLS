using UnityEngine;
using UnityEngine.Events;

public class AlertUI : MonoBehaviour
{
    [SerializeField] private UnityEvent onClose;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 0.25f)
            .setDelay(1f)
            .setEase(LeanTweenType.easeInOutQuad);
    }
    public void Close()
    {
        LeanTween.scale(gameObject, Vector3.zero, 0.25f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() => onClose.Invoke());
    }
}