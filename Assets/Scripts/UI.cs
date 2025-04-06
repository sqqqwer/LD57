using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private CutSceneText cutSceneText;
    [SerializeField] public TextMeshProUGUI toTalkTooltip;
    [SerializeField] public TextMeshProUGUI toUseTooltip;
    [SerializeField] public TextMeshProUGUI toTakeTooltip;
    [SerializeField] public Image blackScreen;
    [SerializeField] public Image whiteScreen;


    public void CutSceneTextSetColor(Color color)
    {
        cutSceneText.SetColor(color);
    }
    public IEnumerator CutSceneText(string text)
    {
        yield return StartCoroutine(cutSceneText.Write(text));
    }
    public IEnumerator CutSceneTextFadeOut(float seconds)
    {
        yield return StartCoroutine(cutSceneText.CutSceneTextFadeOut(seconds));
    }
    public void PickupEmber()
    {
        Debug.Log("+1");
    }
}
