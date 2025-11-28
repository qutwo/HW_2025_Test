
using System.Collections;
using UnityEngine;


public class PulpitSpawnManager : MonoBehaviour
{
    Vector2 spawnPos = new Vector2(0f,0f);
    Vector2[] randomOffsets ;
    [SerializeField] GameObject pulpitPrefab;
    float spawnTime;
    float minDestroyTime;
    float maxDestroyTime;
    void Start()
    {
        randomOffsets = new Vector2[] { new Vector2(9f, 0f), new Vector2(0f, 9f), new Vector2(0f, -9f), new Vector2(-9f, 0) };
                              
       
    }

     IEnumerator SpawnPlatfrom(float time)
     {
       while (true)
       {

            int randomVal = Random.Range(0, 4);
            yield return new WaitForSeconds(time);
            Debug.Log("spawned");
            spawnPos += randomOffsets[randomVal];
            SpawnPulpit();
           
       }

     }

    public void PulpitSpawnData(PulpitData pulData)
    {
        spawnTime = pulData.pulpit_spawn_time;
        minDestroyTime = pulData.min_pulpit_destroy_time;
        maxDestroyTime = pulData.max_pulpit_destroy_time;
        SpawnPulpit();
        StartCoroutine(SpawnPlatfrom(spawnTime));
    }

    public void SpawnPulpit()
    {
        GameObject pulpit = Instantiate(pulpitPrefab, new Vector3(spawnPos.x, 0, spawnPos.y), Quaternion.identity);
        PulpitScript pulpitScript = pulpit.GetComponent<PulpitScript>();
        pulpitScript.DestroyTimeMin = minDestroyTime;
        pulpitScript.DestroyTimeMax = maxDestroyTime;
    }
}
