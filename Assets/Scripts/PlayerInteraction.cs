using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float playerReach = 3f;

    private void Start()
    {
        StartCoroutine(CheckRaycast());
    }
    private void Update()
    {
        if (Input.GetKeyDown("e") & !G.isPause)
        {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit, playerReach))
            {   
                if (hit.collider.CompareTag("Coalman"))
                {
                    hit.collider.GetComponent<Coalman>().dialogueAction.Invoke();
                }
                if (hit.collider.CompareTag("Usable"))
                {
                    hit.collider.GetComponent<Usable>().Use();
                }
                if (hit.collider.CompareTag("Ember"))
                {
                    MetaGame.Instance.embers += 1;
                    hit.collider.transform.DOMoveY(hit.collider.transform.position.y + 0.5f, 0.5f).SetEase(Ease.InBack);
                    hit.collider.transform.DOScale(new Vector3(0f, 0f, 0f), 0.5f).OnComplete(
                        () => Destroy(hit.collider.gameObject)
                    );
                    if (MetaGame.Instance.embers == 1)
                    {
                        StartCoroutine(MetaGame.Instance.Take1Ember());
                    }
                    else if (MetaGame.Instance.embers == 2)
                    {
                        StartCoroutine(MetaGame.Instance.Take2Ember());
                    }
                    else if (MetaGame.Instance.embers == 3)
                    {
                        StartCoroutine(MetaGame.Instance.Take3Ember());
                    }
                    else if (MetaGame.Instance.embers == 4)
                    {
                        StartCoroutine(MetaGame.Instance.Take4Ember());
                    }
                }
            }
        }
    }
    private IEnumerator CheckRaycast()
    {
        while (true)
        {
            if (!G.isPause)
            {
                RaycastHit hit;
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                if (Physics.Raycast(ray, out hit, playerReach))
                {   
                    if (hit.collider.CompareTag("Coalman"))
                    {
                        G.UI.toTalkTooltip.enabled = true;
                    }
                    else if (hit.collider.CompareTag("Usable"))
                    {
                        G.UI.toUseTooltip.enabled = true;
                    }
                    else if (hit.collider.CompareTag("Ember"))
                    {
                        G.UI.toTakeTooltip.enabled = true;
                    }
                    else
                    {
                        G.UI.toTalkTooltip.enabled = false;
                        G.UI.toUseTooltip.enabled = false;
                        G.UI.toTakeTooltip.enabled = false;
                    }
                }
                else
                {
                    G.UI.toTalkTooltip.enabled = false;
                    G.UI.toUseTooltip.enabled = false;
                    G.UI.toTakeTooltip.enabled = false;
                }
            }
            else
            {
                G.UI.toTalkTooltip.enabled = false;
                G.UI.toUseTooltip.enabled = false;
                G.UI.toTakeTooltip.enabled = false;
            }
            yield return new WaitForSeconds(0.03f);
        }
    }
}
