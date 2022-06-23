using UnityEngine;

[CreateAssetMenu(fileName = "Achievement", menuName = "ScriptableObjects/Achievements", order = 1)]
public class CustomAchievement : ScriptableObject
{
    public int index;
    public string message;

    [Header("Animation")]
    public States start;
    public States complete;
}