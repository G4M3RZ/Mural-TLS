using System.Collections;
using UnityEngine;
using UserInterface.FX.Image;

public class MainMenu : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float auto, delay;
    [SerializeField] private GameObject fade;
    private bool complete;

    //private void Awake()
    //{
        
    //}
    //private void Update()
    //{
    //    if (complete) return;

    //    if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
    //    {
    //        LeanTween.cancelAll();
    //        StartCoroutine(ChangeScene());
    //    }
    //}
    public void Button()
    {
        if (complete) return;

        LeanTween.cancelAll();
        StartCoroutine(ChangeScene());
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        ImageEvent.Begin();

        //yield return new WaitForSeconds(auto);
        //if(!complete) StartCoroutine(ChangeScene());
    }
    private IEnumerator ChangeScene()
    {
        complete = true;
        ImageEvent.End();
        StopCoroutine(Start());
        yield return new WaitForSeconds(delay);

        Instantiate(fade, transform).GetComponent<Fade>().SetScene = Scenes.AR;
    }
}