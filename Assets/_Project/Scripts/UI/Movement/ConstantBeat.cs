using UnityEngine;

public class ConstantBeat : MonoBehaviour
{
    private void Start()
    {
        LeanTween.scale(gameObject, Vector2.one * 1.25f, 0.5f);
    }
}