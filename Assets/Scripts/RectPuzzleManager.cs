using UnityEngine;
using UnityEngine.Events;

public class RectPuzzleManager : MonoBehaviour
{
    [SerializeField] public bool onUse = false;
    [SerializeField] public bool isPuzzleComplete = false;
    [SerializeField] private UnityEvent OnPuzzleComplete;
    public void PuzzleComplete()
    {
        isPuzzleComplete = true;
        OnPuzzleComplete.Invoke();
    }
}
