using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance { get; private set; }
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.UnloadSceneAsync(0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
