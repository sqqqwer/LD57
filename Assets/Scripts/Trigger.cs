using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent Event;
    [SerializeField] private bool isOneTime = true;
    private bool isActive = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            Event.Invoke();
        }
        if (isOneTime)
        {
            isActive = false;
        }
    }
}
