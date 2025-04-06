using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using DG.Tweening;

public class RiteAnimation : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;

    public IEnumerator PlayRite()
    {
        playableDirector.Play();
        yield return new WaitForSeconds((float)playableDirector.duration - 1f);
        G.UI.whiteScreen.DOFade(1f, 1f);
        yield return new WaitForSeconds(1f);
    }
}
