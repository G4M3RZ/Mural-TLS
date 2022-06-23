using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RectTransform))]
public class Slide : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private AnimationCurve _curve;
    [Space]
    [SerializeField] private UnityEvent _onOpenSlide, _onCloseSlide;

    private RectTransform _rect;
    private Vector2 _startPos, _endPos;
    private float _width;
    private bool _enable;

    private void Awake() => _rect = GetComponent<RectTransform>();
    private void Start()
    {
        _width = _rect.sizeDelta.x;
        _startPos = _rect.localPosition;
        _endPos = _startPos + Vector2.right * _width;

        _rect.localPosition = _startPos;
    }

    public void SlideButton()
    {
        _enable = !_enable;
        if (_enable) _onOpenSlide.Invoke(); else _onCloseSlide.Invoke();
        LeanTween.moveLocalX(gameObject, _enable ? _endPos.x : _startPos.x, _time).setEase(_curve);
    }
}