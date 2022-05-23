using UnityEngine;

namespace UserInterface.FX.Image
{
    [RequireComponent(typeof(ImageManager))]
    public class TweenTranslate : MonoBehaviour
    {
        [SerializeField] private Vector2 dir;

        private ImageManager manager;
        private Vector2 startPosition, newPosition;

        private void Awake() => manager = GetComponent<ImageManager>();
        private void OnEnable()
        {
            ImageEvent.onEnable += TranslateToPosition;
            ImageEvent.onDisable += TranslateToStart;
        }
        private void OnDisable()
        {
            ImageEvent.onEnable -= TranslateToPosition;
            ImageEvent.onDisable -= TranslateToStart;
        }

        private void Start()
        {
            newPosition = transform.localPosition;
            startPosition = newPosition + (dir.normalized * 100);
            transform.localPosition = startPosition;
        }
        private void TranslateToPosition()
        {
            LeanTween.moveLocal(gameObject, newPosition, manager.InAnim.time)
                .setEase(manager.InAnim.curve)
                .setDelay(manager.InAnim.delay);
        }
        private void TranslateToStart()
        {
            LeanTween.moveLocal(gameObject, startPosition, manager.OutAnim.time)
                .setEase(manager.OutAnim.curve)
                .setDelay(manager.OutAnim.delay);
        }
    }
}