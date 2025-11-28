
using System.Collections;
using UnityEngine;


public class PulpitScript : MonoBehaviour
{
    
    private void Start()
    {
        StartCoroutine(DestroyPulpitAfterTime());
    }
    IEnumerator DestroyPulpitAfterTime()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }


}
