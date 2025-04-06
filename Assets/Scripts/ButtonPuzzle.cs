using UnityEngine;
using TMPro;

public class ButtonPuzzle : Usable
{
    [SerializeField] public Material litButtonMaterial;
    [SerializeField] public Material unlitButtonMaterial;
    [SerializeField] private ButtonPuzzleManager buttonPuzzleManager;
    [SerializeField] private MeshRenderer button;
    public int number;
    public bool isLit = false;

    private void Start()
    {
        if (isLit)
        {
            button.material = litButtonMaterial;
        }
        else
        {
            button.material = unlitButtonMaterial;
        }
    }
    public override void Use()
    {
        buttonPuzzleManager.ButtonPress(number);
    }
    public void Activate()
    {
        isLit = true;
        button.material = litButtonMaterial;
    }
    public void Deactivate()
    {
        isLit = false;
        button.material = unlitButtonMaterial;
    }
}
