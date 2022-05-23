using UnityEngine;

namespace UserInterface.FX.Image
{
    [RequireComponent(typeof(CanvasGroup), typeof(ImageManager))]
    public class TweenFade : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        private ImageManager manager;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            manager = GetComponent<ImageManager>();
        }
        private void OnEnable()
        {
            ImageEvent.onEnable += FadeIn;
            ImageEvent.onDisable += FadeOut;
        }
        private void OnDisable()
        {
            ImageEvent.onEnable -= FadeIn;
            ImageEvent.onDisable -= FadeOut;
        }

        private void Start()
        {
            canvasGroup.alpha = 0;
        }
        private void FadeIn()
        {
            LeanTween.alphaCanvas(canvasGroup, 1, manager.InAnim.time)
                .setDelay(manager.InAnim.delay)
                .setEase(manager.InAnim.curve);
        }
        private void FadeOut()
        {
            LeanTween.alphaCanvas(canvasGroup, 0, manager.OutAnim.time)
                .setDelay(manager.OutAnim.delay)
                .setEase(manager.OutAnim.curve);
        }
    }
}