using UnityEngine;
using Unity.Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine.Events;

public class Coalman : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private Transform standartLookTarget;
    [SerializeField] private float lookRadius = 3f;
    [SerializeField] private GameObject wobbleHead;
    [SerializeField] private bool isHeadLook = false;
    [SerializeField] private bool isWobbling = false;
    [SerializeField] private float wobbleSpeed = 1f;
    [SerializeField] private float wobbleaAmplitude = 2f;
    [SerializeField] private bool isRestWobbling = false;
    [SerializeField] private float restWobbleSpeed = 1f;
    [SerializeField] private float restWobbleaAmplitude = 2f;
    [SerializeField] public UnityEvent dialogueAction;
    private Vector3 originalRotation;
    private float restWobbleRandom;

    private void Start()
    {
        originalRotation = wobbleHead.transform.localEulerAngles;
        restWobbleRandom = Random.Range(-0.8f, 0.8f);
    }
    private void Update()
    {
        if (isHeadLook)
        {
            float distanceToPlayer = Vector3.Distance(
                G.player.transform.position,
                transform.position
            );
            head.transform.DOKill();
            if (distanceToPlayer < lookRadius)
            {
                head.transform.DOLookAt(G.player.transform.position, 0.5f);
            }
            else
            {
                head.transform.DOLookAt(standartLookTarget.position, 0.5f);
            }
        }
        if (isWobbling)
        {
            float wobbleX = Mathf.Sin(Time.time * wobbleSpeed) * wobbleaAmplitude;
            
            wobbleHead.transform.localEulerAngles = originalRotation + new Vector3(wobbleX, 0, 0);
        }
        else if (isRestWobbling)
        {
            float wobbleX = (Mathf.Sin(Time.time * restWobbleSpeed) + restWobbleRandom) * restWobbleaAmplitude;
            float wobbleZ = (Mathf.Cos(Time.time * restWobbleSpeed) + restWobbleRandom) * restWobbleaAmplitude;
            
            wobbleHead.transform.localEulerAngles = originalRotation + new Vector3(wobbleX, 0, wobbleZ);
        }
    }
    public void StartMainQuestDialogue()
    {
        StartCoroutine(_StartMainQuestDialogue());
    }
    private IEnumerator _StartMainQuestDialogue()
    {
        G.UI.CutSceneTextSetColor(Color.white);
        G.isPause = true;
        if (MetaGame.Instance.embers >= 4)
        {
            isWobbling = true;
            yield return StartCoroutine(G.UI.CutSceneText($"\"Ah... You've brought the embers\""));
            isWobbling = false;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            isWobbling = true;
            yield return StartCoroutine(G.UI.CutSceneText($"\"We have been awaiting you\""));
            isWobbling = false;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            isWobbling = true;
            yield return StartCoroutine(G.UI.CutSceneText($"\"Now shall we make ready the great rite.\""));
            isWobbling = false;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));

            G.UI.blackScreen.DOFade(1f, 1f);
            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(2f);
            G.UI.blackScreen.DOFade(0f, 2f);

            G.music.Play(G.music.tribeEnd);

            yield return StartCoroutine(G.rite.PlayRite());
            yield return StartCoroutine(MetaGame.Instance.EndGameTribe());
        }
        else
        {
            isWobbling = true;
            yield return StartCoroutine(G.UI.CutSceneText($"\"Hey, you only have {MetaGame.Instance.embers} embers!\""));
            isWobbling = false;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            isWobbling = true;
            yield return StartCoroutine(G.UI.CutSceneText($"\"You need 4!\""));
            isWobbling = false;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            isWobbling = true;
            yield return StartCoroutine(G.UI.CutSceneText($"\"Come back when you've got them all\""));
            isWobbling = false;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));
            G.isPause = false;
        }

    }
    public void StartMiniDialogueKid1()
    {
        StartCoroutine(_StartMiniDialogueKid1());
    }
    private IEnumerator _StartMiniDialogueKid1()
    {
        G.isPause = true;
        G.UI.CutSceneTextSetColor(Color.white);
        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"Check this out!\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"That light is so beautiful!\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));
        G.isPause = false;
    }
    public void StartMiniDialogueKid2Mom()
    {
        StartCoroutine(_StartMiniDialogueKid2Mom());
    }
    private IEnumerator _StartMiniDialogueKid2Mom()
    {
        G.isPause = true;
        G.UI.CutSceneTextSetColor(Color.white);
        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"I...\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"<link=shake>\"I... don’t know.\"</link>"));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));
        G.isPause = false;
    }
    public void StartMiniDialogueKid2()
    {
        StartCoroutine(_StartMiniDialogueKid2());
    }
    private IEnumerator _StartMiniDialogueKid2()
    {
        G.isPause = true;
        G.UI.CutSceneTextSetColor(Color.white);
        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"<link=wiggle>\"Mom! Mom!\"</link>"));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"Dad went to collect embers for the ritual, right?\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"It’s been quite a while!\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"When is he coming back?\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));
        G.isPause = false;
    }
    public void StartMiniDialogueAloneMan()
    {
        StartCoroutine(_StartMiniDialogueAloneMan());
    }
    private IEnumerator _StartMiniDialogueAloneMan()
    {
        G.isPause = true;
        G.UI.CutSceneTextSetColor(Color.white);
        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"<link=shake>\"WHAT?\"</link>"));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"<link=shake>\"ARE YOU GOING TO PREPARE THE RITUAL?\"</link>"));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"<link=shake>\"TRUST ME, YOU DON'T WANT TO DO THIS\"</link>"));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"<link=shake>\"WE DON'T KNOW WHAT WILL HAPPEN AFTER THE RITUAL\"</link>"));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"<link=shake>\"WHAT IF SOMETHING TERRIBLE HAPPENS?\"</link>"));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(0.5f));
        G.isPause = false;
    }
    public void StartDialogue()
    {
        StartCoroutine(Dialogue());
    }
    private IEnumerator Dialogue()
    {
        G.UI.CutSceneTextSetColor(Color.white);
        G.isPause = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"Hey!!!\""));
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        CinemachinePanTilt cinemachinePanTilt = G.cameraPlayer.GetComponent<CinemachinePanTilt>();
        cinemachinePanTilt.enabled = false;
        G.cameraPlayer.transform.DOLookAt(head.transform.position, 2f);
        yield return new WaitForSeconds(2f);

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"Finally decided to perform the ritual, huh?\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"No one knows what will happen when the rite is completed\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"The ritual requires <#{G.colorRed}>4 big embers</color> - go collect them\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"Looks like they went up the staircase inside the rooms\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"When you find all of it, come talk to me.\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"\"Just don’t get too close to the light\""));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        isWobbling = true;
        yield return StartCoroutine(G.UI.CutSceneText($"<#{G.colorRed}>\"<link=shake>No one has ever returned from there</link>\"</color>"));
        isWobbling = false;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));


        yield return StartCoroutine(G.UI.CutSceneTextFadeOut(1f));

        cinemachinePanTilt.PanAxis.Value = G.cameraPlayer.transform.eulerAngles.y;
        cinemachinePanTilt.TiltAxis.Value = G.cameraPlayer.transform.eulerAngles.x;
        cinemachinePanTilt.enabled = true;
        G.isPause = false;
    }
}
