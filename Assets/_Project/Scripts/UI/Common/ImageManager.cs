using UnityEngine;

namespace UserInterface.FX.Image
{
    public class ImageManager : MonoBehaviour
    {
        [System.Serializable] public struct UIAnimation
        {
            public AnimationCurve curve;
            [Range(0, 2)] public float time;
            [Range(0, 5)] public float delay;
        }
        [SerializeField] private UIAnimation inAnim, outAnim;

        public UIAnimation InAnim { get => inAnim; }
        public UIAnimation OutAnim { get => outAnim; }
    }
}