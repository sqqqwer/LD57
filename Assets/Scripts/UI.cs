using System.Collections;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private CutSceneText cutSceneText;


    public IEnumerator CutSceneText(string text)
    {
        yield return StartCoroutine(cutSceneText.Write(text));
    }
}
