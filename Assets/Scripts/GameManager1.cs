using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;

    public static GameManager1 sgtGameManager;

    void Awake () {
        if(sgtGameManager!=null && sgtGameManager!=this) {
            Destroy(gameObject);
            return;
        }
        sgtGameManager=this;
    }

    public void CompleteLevel () {
        //Debug.Log("LEVEL WON!");
        completeLevelUI.SetActive(true);
    }

    public void EndGame () {
        if(gameHasEnded == false) {
            gameHasEnded = true;
            //Debug.Log("GAME OVER");
            PlayerPrefs.SetInt("numLives", (PlayerPrefs.GetInt("numLives")-1));
            PlayerPrefs.Save();
            if(PlayerPrefs.GetInt("numLives")==0) {
                SceneManager.LoadScene("GameOver");
            }
            Invoke("Restart", restartDelay);
        }
    }

    void Restart () { //quando il cubo cade dal pavimento, il gioco ricomincia
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
