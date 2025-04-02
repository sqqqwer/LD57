using System.Collections;
using UnityEngine;

public class MetaGame : MonoBehaviour
{
    public static MetaGame Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void StartGame()
    {
        StartCoroutine(StandartGame());
    }
    public IEnumerator StandartGame()
    {
        while (true)
        {
            yield return StartCoroutine(G.UI.CutSceneText($"<#{G.colorRed}><link=shake>LD 57</link></color>"));
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
    }
}
