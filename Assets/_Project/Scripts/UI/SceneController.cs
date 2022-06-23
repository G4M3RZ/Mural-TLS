using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject[] ui;

    public void OpernURL(string url) => Application.OpenURL(url);
    public void ShareButton() => StartCoroutine(TakeScreenshotAndShare());

    public void CutScene(int index) => SceneManager.LoadScene(index);

    private void HideUI(bool active)
    {
        foreach (var item in ui) item.SetActive(!active);
    }
    private IEnumerator TakeScreenshotAndShare()
    {
        HideUI(true);

        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        yield return new WaitForEndOfFrame();

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("TLS!").SetText("TLS!")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

        HideUI(false);
    }
}