using System.IO;
using UnityEngine;

[System.Serializable]
class player_data
{
    float speed;
}
[System.Serializable]
class pulpit_data
{
    float minPulpitDestroyTime;

    float maxPulpitDestroyTime;

    float PulpitSpawnTime;

}
[System.Serializable]
class DoofusDiary
{
    string[] diaryEntries;
}

public class JsonReader : MonoBehaviour
{
    private void Start()
    {
        JsonRead();
    }
    void JsonRead()
    {
        string json = File.ReadAllText("Assets/Json/doofus_diary.json");
        player_data dd = JsonUtility.FromJson<player_data>(json);
        print(dd);
    }
}
