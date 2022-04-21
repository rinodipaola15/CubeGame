using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    
    public void LoadNextLevel () {
        if(SceneManager.GetActiveScene()==SceneManager.GetSceneByName("Level03Easy") || SceneManager.GetActiveScene()==SceneManager.GetSceneByName("Level03Medium") || SceneManager.GetActiveScene()==SceneManager.GetSceneByName("Level03Hard"))
            SceneManager.LoadScene("Credits");
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
