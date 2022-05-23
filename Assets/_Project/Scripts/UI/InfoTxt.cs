using System.Collections;
using UnityEngine;
using TMPro;

public class InfoTxt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_text;
    private bool finish;

    private void Update()
    {
        if (finish) return;

        if(Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            BanishText();
        }
    }

    private IEnumerator Start()
    {
        m_text.alpha = 0;
        LeanTween.value(gameObject, 0, 1, 0.25f).setOnUpdate((float v) => m_text.alpha = v);
        yield return new WaitForSeconds(5f);
        BanishText();
    }
    private void BanishText()
    {
        if (finish) return;

        finish = true;
        LTDescr tween = LeanTween.value(gameObject, 1, 0, 0.5f).setOnUpdate((float v) =>
        {
            m_text.alpha = v;
        });

        tween.setDestroyOnComplete(true);
    }
}