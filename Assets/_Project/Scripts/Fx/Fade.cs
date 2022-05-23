using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    None = -1,
    Menu = 0,
    AR = 1,
    Exit = 1000
}
public class Fade : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_cGroup;
    [SerializeField, Range(0, 1)] private float m_time;

    [SerializeField] private Scenes m_scenes;
    public Scenes SetScene { set => m_scenes = value; }

    private void Start()
    {
        bool none = m_scenes == Scenes.None;
        m_cGroup.alpha = none ? 1 : 0;
        float to = none ? 0 : 1;

        LTDescr tween = LeanTween.alphaCanvas(m_cGroup, to, m_time);
        tween.setOnComplete(() =>
        {
            if (none) Destroy(gameObject);
            else
            {
                if (m_scenes != Scenes.Exit) SceneManager.LoadSceneAsync((int)m_scenes, LoadSceneMode.Single);
                else Application.Quit();
            }
        });
    }
}