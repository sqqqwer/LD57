using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPuzzleManager : MonoBehaviour
{
    [SerializeField] private List<ButtonPuzzle> buttonList;
    [SerializeField] private UnityEvent winEvent;

    public void ButtonPress(int number)
    {
        if (number == 0)
        {
            ActivateButton(0);
            ActivateButton(1);
        }
        else if (number == buttonList.Count - 1)
        {
            ActivateButton(buttonList.Count - 2);
            ActivateButton(buttonList.Count - 1);
        }
        else
        {
            ActivateButton(number - 1);
            ActivateButton(number);
            ActivateButton(number + 1);
        }
        CheckWin();
    }
    private void CheckWin()
    {
        List<ButtonPuzzle> litButtons = buttonList.FindAll(x => x.isLit == true);
        if (litButtons.Count == buttonList.Count)
        {
            winEvent.Invoke();
        }
    }
    private void ActivateButton(int number)
    {
        if (buttonList[number].isLit == true)
        {
            buttonList[number].Deactivate();
        }
        else
        {
            buttonList[number].Activate();
        }
    }
}
