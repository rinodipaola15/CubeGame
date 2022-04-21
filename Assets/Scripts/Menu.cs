using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void StartGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("numLives", 5);
        PlayerPrefs.Save();
    }

    public void QuitGame () {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
