using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PulpitScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pulpitText;
    [SerializeField] GameObject pulpitUI;
    [SerializeField] UnityEvent ScoreEvent;

    private Tween tickingTween;

    public void spawn(Vector3 spawnPos, float destroytime)
    {
        transform.position = spawnPos;
        transform.localScale = new Vector3(9f, 1f, 9f);
        pulpitUI.SetActive(true);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;

        
    
        
       
        StartTickingAnimation();

        StartCoroutine(DestroyPulpitAfterTime(destroytime));
        StartCoroutine(Countdown(destroytime));
    }

    void StartTickingAnimation()
    {
       
        tickingTween = pulpitText.transform.DOScale(1.2f, 0.1f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    IEnumerator DestroyPulpitAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        
        tickingTween?.Kill();

      
        pulpitUI.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator Countdown(float time)
    {
        while (time > 0)
        {
            pulpitText.text = time.ToString("F1");
            yield return null;
            time -= Time.deltaTime;
        }

        pulpitText.text = "0";
    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreEvent?.Invoke();
        
       
    }
    
    private void OnDestroy()
    {
       
        tickingTween?.Kill();
    }
}