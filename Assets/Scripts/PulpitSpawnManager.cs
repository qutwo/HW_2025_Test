
using System.Collections;
using UnityEngine;

struct PulpitSpawnData
{
 

}
public class PulpitSpawnManager : MonoBehaviour
{
    Vector2 spawnPos = new Vector2(0f,0f);
    Vector2[] randomOffsets ;
    [SerializeField] GameObject pulpitPrefab;
    void Start()
    {
        randomOffsets =new Vector2[]{ new Vector2(4.5f, 0f), new Vector2(0f, 4.5f), new Vector2(0f, -4.5f), new Vector2(-4.5f, 0)}
                          
        ;
        StartCoroutine(SpawnPlatfrom());
    }

     IEnumerator SpawnPlatfrom()
     {
       while (true)
        {

            int randomVal = Random.Range(0, 4);
            yield return new WaitForSeconds(1);
            spawnPos += randomOffsets[randomVal];
            Instantiate(pulpitPrefab, new Vector3(spawnPos.x, 0,spawnPos.y), Quaternion.identity);
        }

    }
}
