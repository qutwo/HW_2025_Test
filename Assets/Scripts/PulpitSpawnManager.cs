
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class PulpitSpawnManager : MonoBehaviour
{
    Vector2 spawnPos = new Vector2(0f,0f);
    Vector2[] randomOffsets ;
 
    [SerializeField] UnityEvent<Vector3,float>[] pulpitEvents;

    float spawnTime;
    float minDestroyTime;
    float maxDestroyTime;
    int i = 1;
    void Start()
    {
        randomOffsets = new Vector2[] { new Vector2(9f, 0f), new Vector2(0f, 9f), new Vector2(0f, -9f), new Vector2(-9f, 0) };
                              
       
    }

     IEnumerator SpawnPlatfrom()
     {
       while (true)
       {

            int randomVal = Random.Range(0, 4);
            yield return new WaitForSeconds(spawnTime);
            Debug.Log("spawned");
            spawnPos += randomOffsets[randomVal];
            float time = Random.Range(minDestroyTime, maxDestroyTime);
            pulpitEvents[i%2]?.Invoke(new Vector3(spawnPos.x,0f,spawnPos.y),time);
            i++;
        }

     }

    public void PulpitSpawnData(PulpitData pulData)
    {
        spawnTime = pulData.pulpit_spawn_time;
        minDestroyTime = pulData.min_pulpit_destroy_time;
        maxDestroyTime = pulData.max_pulpit_destroy_time;
        
        StartCoroutine(SpawnPlatfrom());
        float time = Random.Range(minDestroyTime, maxDestroyTime);
        pulpitEvents[0]?.Invoke(spawnPos,time);
    }

   
}
