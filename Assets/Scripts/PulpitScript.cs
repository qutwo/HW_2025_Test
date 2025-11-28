
using System.Collections;
using TMPro;
using UnityEngine;


public class PulpitScript : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI pulpitText;
    [SerializeField]GameObject pulpitUI;
    

    public void spawn(Vector3 spawnPos,float destroytime)
    {
        transform.position = spawnPos;
        pulpitUI.SetActive(true);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(DestroyPulpitAfterTime(destroytime));
        StartCoroutine(Countdown(destroytime));
    }
    IEnumerator DestroyPulpitAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        pulpitUI.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
    IEnumerator Countdown(float time)
    {
        while (true)
        {
            pulpitText.text = time.ToString("F1");
            yield return null;
            time -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }





}
