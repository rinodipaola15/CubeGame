using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public Text lifeText;
    public Text nickText;
    public Text timerText;
    private float startTime;
    public Text powerupText;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        PlayerPrefs.SetString("powerup", "");
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = (PlayerPrefs.GetInt("numLives")).ToString();
        nickText.text = (PlayerPrefs.GetString("nickname"));
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
        powerupText.text = PlayerPrefs.GetString("powerup");
    }
}
