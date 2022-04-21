using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start() {
        Destroy(GameObject.Find("AudioMenu"));
    }

    public void LoadLevel1()
    {
        if(PlayerPrefs.GetString("Difficulty")=="Easy")
            SceneManager.LoadScene("Level01Easy");
        if(PlayerPrefs.GetString("Difficulty")=="Medium")
            SceneManager.LoadScene("Level01Medium");
        if(PlayerPrefs.GetString("Difficulty")=="Hard")
            SceneManager.LoadScene("Level01Hard");
        Debug.Log(PlayerPrefs.GetString("Difficulty"));
    }
}
