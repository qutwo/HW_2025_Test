using UnityEngine;

public class RestartScript : MonoBehaviour
{
   public void Reload()
    {
              UnityEngine.SceneManagement.SceneManager.LoadScene(
           UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
