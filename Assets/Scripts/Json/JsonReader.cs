using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class JsonReader : MonoBehaviour
{
   
    [SerializeField] private string jsonUrl = "https://s3.ap-south-1.amazonaws.com/superstars.assetbundles.testbuild/doofus_game/doofus_diary.json";

    [SerializeField] UnityEvent<float> DoofusSpeedEvent;
    [SerializeField] UnityEvent<PulpitData> PulpitDataEvent;

    private void Start()
    {
        StartCoroutine(JsonReadFromUrl());
    }

    IEnumerator JsonReadFromUrl()
    {
    

        using (UnityWebRequest webRequest = UnityWebRequest.Get(jsonUrl))
        {
           
         

            yield return webRequest.SendWebRequest();

          
            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error fetching JSON: " + webRequest.error);
                Debug.LogError("Response Code: " + webRequest.responseCode);

                jsonReadLocally();
            }
            else
            {
                
                string json = webRequest.downloadHandler.text;
                DoofusDiary doofDiary = JsonUtility.FromJson<DoofusDiary>(json);
                DoofusSpeedEvent?.Invoke(doofDiary.player_data.speed);
                PulpitDataEvent?.Invoke(doofDiary.pulpit_data);


            }
        }
    }
    void jsonReadLocally()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/doofus_diary.json");
        DoofusDiary doofDiary = JsonUtility.FromJson<DoofusDiary>(json);
        DoofusSpeedEvent?.Invoke(doofDiary.player_data.speed);
        PulpitDataEvent?.Invoke(doofDiary.pulpit_data);

    }
}

