using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Credits : MonoBehaviour
{

    public Dictionary<string, float> ScoreList = new Dictionary<string, float>();
    public System.Random rand = new System.Random();
    public float randomKey;

    public Text scoreText;
    public float resScore;

    void Start() {
        Cursor.visible = true;
        resScore = PlayerPrefs.GetFloat("ScoreLevel01") + PlayerPrefs.GetFloat("ScoreLevelo2") + PlayerPrefs.GetFloat("ScoreLevel03");

        //randomKey = rand.Next(0, 100000);
        //ScoreList.Add(randomKey, resScore);

        /*if(resScore < PlayerPrefs.GetFloat("Highscore") || PlayerPrefs.GetFloat("Highscore")==0.0f || PlayerPrefs.GetFloat("Highscore")==0)
            PlayerPrefs.SetFloat("Highscore", resScore);*/
        scoreText.text = "Score: " + resScore;

        /*foreach(var score in ScoreList) {
            Debug.Log(score.Value);
        }*/
    }
   
    public void Quit () {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void RestartGame () {
        SceneManager.LoadScene("Menu");
    }

}
