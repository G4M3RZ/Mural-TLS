using UnityEngine;

namespace UserInterface.FX.Image
{
    [RequireComponent(typeof(ImageManager))]
    public class TweenScale : MonoBehaviour
    {
        [SerializeField] private bool dependecy;
        private ImageManager manager;

        private void Awake() => manager = GetComponent<ImageManager>();
        private void OnEnable()
        {
            if (dependecy) return;
            ImageEvent.onEnable += ScaleIn;
            ImageEvent.onDisable += ScaleOut;
        }
        private void OnDisable()
        {
            if (!dependecy) return;
            ImageEvent.onEnable -= ScaleIn;
            ImageEvent.onDisable -= ScaleOut;
        }

        private void Start()
        {
            transform.localScale = Vector3.zero;
        }
        public void ScaleIn()
        {
            LeanTween.scale(gameObject, Vector3.one, manager.InAnim.time)
                .setEase(manager.InAnim.curve)
                .setDelay(manager.InAnim.delay);
        }
        public void ScaleOut()
        {
            LeanTween.scale(gameObject, Vector3.zero, manager.OutAnim.time)
                .setEase(manager.OutAnim.curve)
                .setDelay(manager.OutAnim.delay);
        }
    }
}