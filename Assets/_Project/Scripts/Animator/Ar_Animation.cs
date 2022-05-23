using UnityEngine;

public class Ar_Animation : MonoBehaviour
{
    [SerializeField] private TrailRenderer[] trails;

    public void SetActive()
    {
        foreach (var item in trails)
        {
            item?.Clear();
        }
    }
}