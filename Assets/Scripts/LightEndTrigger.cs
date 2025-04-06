using UnityEngine;

public class LightEndTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (MetaGame.Instance.embers >= 4)
        {
            StartCoroutine(MetaGame.Instance.EndGameLightTrue());
        }
        else
        {
            StartCoroutine(MetaGame.Instance.EndGameLightBad());
        }
    }
}
