
using System.Collections;
using UnityEngine;


public class PulpitScript : MonoBehaviour
{
    float destroyTimeMin;
    float destroyTimeMax;
    private void Start()
    {
        StartCoroutine(DestroyPulpitAfterTime(destroyTimeMin,destroyTimeMax));
    }
    IEnumerator DestroyPulpitAfterTime(float timeMin,float timeMax)
    {
        float time = Random.Range(timeMin, timeMax);
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    public float DestroyTimeMin
    {
       
        set { destroyTimeMin = value; }
    }
    public float DestroyTimeMax
    {
       
        set { destroyTimeMax = value; }
    }


}
