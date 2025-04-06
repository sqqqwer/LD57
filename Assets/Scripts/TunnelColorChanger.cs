using System.Collections;
using UnityEngine;
using DG.Tweening;

public class TunnelColorChanger : MonoBehaviour
{
    [SerializeField] private Material tunnelMaterial;
    [SerializeField] private Material lightRayMaterial;
    [SerializeField] private Material coalHumansMaterial;
    [SerializeField] private Material coalHumansEyeMaterial;

    void Update()
    {
        float test = G.player.transform.position.y/45f;
        lightRayMaterial.SetFloat("_TotalAlpha", 0.7f - test);
        tunnelMaterial.color = new Color(test + 0.02f, test + 0.02f, test + 0.02f, 1f);
        if (G.player.transform.position.y >= 1)
        {
            float coalHumansAlpha = G.player.transform.position.y/15f;
            coalHumansMaterial.color = new Color(0f, 0f, 0f, 1 - coalHumansAlpha);
            coalHumansEyeMaterial.color = new Color(1f, 1f, 1f, 1 - coalHumansAlpha);
        }
    }
    public IEnumerator ChangeBWColor(float value)
    {
        tunnelMaterial.DOColor(new Color(value, value, value, 1f), 1f);
        yield return new WaitForSeconds(1f);
    }
}
