using DG.Tweening;
using System.Collections;
using EasyTextEffects;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneText : MonoBehaviour
{
    [SerializeField] private TextEffect cutSceneText;
    [SerializeField] private Image textWritedSymbol;
    [SerializeField] private bool isCutSceneTextWrited = false;

    public IEnumerator Write(string text)
    {
        cutSceneText.text.DOFade(1f, 0f);
        textWritedSymbol.DOFade(0f, 0f);
        isCutSceneTextWrited = false;
        yield return new WaitForSeconds(0.05f);
        cutSceneText.text.transform.localPosition = new Vector3(10000f, 10000f, 0f);
        cutSceneText.text.text = text;
        cutSceneText.Refresh();
        cutSceneText.StartManualEffects();
        yield return new WaitForSeconds(0.02f);
        cutSceneText.text.transform.localPosition = new Vector3(0f, 0f, 0f);

        float secondsToWait = text.Length * 0.1f;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) | isCutSceneTextWrited);
        textWritedSymbol.DOFade(1f, 0f);

        cutSceneText.StopManualEffects();
        yield return new WaitForSeconds(0.05f);
        isCutSceneTextWrited = false;
    }
    public void CutSceneTextWrited()
    {
        isCutSceneTextWrited = true;
    }
    public IEnumerator CutSceneTextFadeOut(float seconds)
    {
        cutSceneText.text.DOFade(0f, seconds);
        textWritedSymbol.DOFade(0f, seconds);
        yield return new WaitForSeconds(seconds);
        cutSceneText.text.text = " ";
    }
}
