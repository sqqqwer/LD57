using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.Cinemachine;

public class MetaGame : MonoBehaviour
{
    public static MetaGame Instance;
    public bool lightBad = false;
    public bool lightTrue = false;
    public bool tribeEnd = false;
    public int _embers;
    public int embers
    {
        get => _embers;
        set
        {
            if (_embers != value)
            {
                _embers = value;
                G.UI.PickupEmber();
            }
        }
    }
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
        StartCoroutine(StartGameCutscene());
    }
    public IEnumerator StartGameCutscene()
    {
        embers = 0;
        G.isPause = true;
        if (lightBad || lightTrue || tribeEnd)
        {
            string endingStr = "Endings completed:";
            if (lightBad)
            {
                endingStr += "\nEnding 1/3: \"Yet Another Lost One\"";
            }
            if (lightTrue)
            {
                endingStr += "\nEnding 2/3: \"Eternal Darkness\"";
            }
            if (tribeEnd)
            {
                endingStr += "\nEnding 3/3: \"Cycle\"";
            }
            yield return StartCoroutine(G.UI.CutSceneText(endingStr));
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }

        G.UI.blackScreen.DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(G.UI.CutSceneText($"You are a coalling of the Coal Tribe"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return StartCoroutine(G.UI.CutSceneText($"The meaning of your tribe's existence was forgotten generations back"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return StartCoroutine(G.UI.CutSceneText($"Each member of the tribe shares but a single certainty - the Great Ritual must be fulfilled."));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(1f));
        G.isPause = false;
    }
    public IEnumerator EndGameLightBad()
    {
        G.isPause = true;

        G.music.Play(G.music.lightEnd);
        
        G.UI.CutSceneTextSetColor(Color.black);

        yield return StartCoroutine(G.UI.CutSceneText($"Everything is white"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"You used to believe approaching the light would bring clarity."));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"Yet the light reveals just as little as the deepest blackness."));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"If only you had gathered more coal..."));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"There's no returning now"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"The ritual will find another"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"<link=shake><#{G.colorRed}>THE CYCLE CONTINUES</color></link>"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
    
        MetaGame.Instance.lightBad = true;
    
        yield return StartCoroutine(G.UI.CutSceneText($"Ending 1/3: \"Yet Another Lost One\""));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(1f));
        
        G.UI.blackScreen.DOFade(1f, 1f);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public IEnumerator EndGameLightTrue()
    {
        G.isPause = true;

        G.music.Play(G.music.lightEnd);

        G.UI.CutSceneTextSetColor(Color.black);

        yield return StartCoroutine(G.UI.CutSceneText($"Everything is white"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"You used to believe approaching the light would bring clarity"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"Yet the light reveals just as little as the deepest blackness"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"This revelation sickens you"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"You take the coals and scar the white expanse, smearing darkness across existence itself"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));

        yield return StartCoroutine(G.drawingController.StartDraw());
        
        G.UI.CutSceneTextSetColor(Color.white);

        yield return StartCoroutine(G.UI.CutSceneText($"Now the same gloom reigns here as in the abyss"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"You've damned your people to endless night"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"<link=shake><#{G.colorRed}>THE CYCLE IS BROKEN</color></link>"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
    
        MetaGame.Instance.lightTrue = true;
    
        yield return StartCoroutine(G.UI.CutSceneText($"Ending 2/3: \"Eternal Darkness\""));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(1f));

        G.UI.blackScreen.DOFade(1f, 1f);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public IEnumerator EndGameTribe()
    {
        G.isPause = true;
        G.UI.CutSceneTextSetColor(Color.black);

        yield return StartCoroutine(G.UI.CutSceneText($"You have performed the Great Rite"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"The radiant light that guided your whole existence has been extinguished"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"Now you become the Luminous Side"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"What fate awaits those now trapped in the extinguished realm?"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"<link=shake><#{G.colorRed}>THE CYCLE CONTINUES</color></link>"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        MetaGame.Instance.tribeEnd = true;

        yield return StartCoroutine(G.UI.CutSceneText($"\nEnding 3/3: \"Cycle\""));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(1f));
        yield return new WaitForSeconds(1f);

        G.UI.blackScreen.DOFade(1f, 1f);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public IEnumerator Take1Ember()
    {
        G.isPause = true;

        yield return StartCoroutine(G.UI.CutSceneText($"The first Ember"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"That was easy"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));
        G.isPause = false;
    }
    public IEnumerator Take2Ember()
    {
        G.isPause = true;

        yield return StartCoroutine(G.UI.CutSceneText($"It seems someone locked this coal in here"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"What could possibly make someone do this?"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));
        G.isPause = false;
    }
    public IEnumerator Take3Ember()
    {
        G.isPause = true;

        G.UI.CutSceneTextSetColor(Color.black);

        yield return StartCoroutine(G.UI.CutSceneText($"Who could have built all these mechanisms?"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"Alas, no one in my tribe remembers it"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));
        G.isPause = false;
    }
    public IEnumerator Take4Ember()
    {
        G.isPause = true;

        G.UI.CutSceneTextSetColor(Color.black);

        yield return StartCoroutine(G.UI.CutSceneText($"I've collected all the embers"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"Now it's time to return to my tribe"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"..."));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneText($"Should I investigate that glow?"));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));
        G.isPause = false;
    }
}
