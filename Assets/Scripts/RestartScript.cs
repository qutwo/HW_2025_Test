using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScript : MonoBehaviour
{
   public void Reload()
    {
              UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
