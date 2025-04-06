using UnityEngine;
using DG.Tweening;

public class RectPuzzle : Usable
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private Vector3 raycastToStart;
    [SerializeField] private Vector3 raycastToEnd;
    [SerializeField] private float raycastLength;
    [SerializeField] public bool isOnEndPosition = false;
    [SerializeField] private RectPuzzleManager rectPuzzleManager;
    [SerializeField] private bool isKey;
    public override void Use()
    {
        if (!rectPuzzleManager.onUse & !rectPuzzleManager.isPuzzleComplete)
        {
            transform.DOKill();
            RaycastHit hit;
            Ray ray;
            Vector3 targetPositon;
            Vector3 targetRaycast;
            rectPuzzleManager.onUse = true;
            if (isOnEndPosition)
            {
                targetPositon = startPosition;
                targetRaycast = raycastToStart;
            }
            else
            {
                targetPositon = endPosition;
                targetRaycast = raycastToEnd;
            }
            ray = new Ray(
                transform.position,
                (transform.TransformPoint(targetRaycast) - transform.TransformPoint(Vector3.zero)).normalized
            );
            raycastLength = Vector3.Distance(
                transform.TransformPoint(Vector3.zero),
                transform.TransformPoint(targetRaycast)
            );
            if (Physics.Raycast(ray, out hit, raycastLength))
            {
                if (hit.collider.CompareTag("Usable"))
                {
                    Shake();
                }
                else
                {
                    transform.DOLocalMove(targetPositon, 0.5f).OnComplete(
                        () => AfterMove()
                    );
                }
            }
            else
            {
                transform.DOLocalMove(targetPositon, 0.5f).OnComplete(
                    () => AfterMove()
                );
            }
        }
    }
    private void Shake()
    {
        rectPuzzleManager.onUse = true;
        transform.DOShakePosition(0.2f, strength:0.1f, vibrato:200).OnComplete(
            () => rectPuzzleManager.onUse = false
        );
    }
    private void AfterMove()
    {
        if (isKey)
        {
            rectPuzzleManager.PuzzleComplete();
        }
        rectPuzzleManager.onUse = false;
        isOnEndPosition = !isOnEndPosition;
    }
}
