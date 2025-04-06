using UnityEngine;
using DG.Tweening;

public class Bars : MonoBehaviour
{
    [SerializeField] private GameObject bars;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private AudioSource audioSource;

    public void Open()
    {
        audioSource.Play();
        bars.transform.DOLocalMoveY(-15f, 2f).SetEase(Ease.InOutBack);
        boxCollider.enabled = false;
    }
}
