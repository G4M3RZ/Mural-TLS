using UnityEngine;

public class ObjScale : MonoBehaviour
{
    public void Show() => LeanTween.scale(gameObject, Vector3.one, 1);
    public void Hide() => LeanTween.scale(gameObject, Vector3.zero, 1);
}