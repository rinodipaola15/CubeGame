using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;

    void Start() {
        if(SceneManager.GetActiveScene().name=="Level01")
            PlayerPrefs.SetFloat("ScoreLevel01", 0);
        if(SceneManager.GetActiveScene().name=="Level02")
            PlayerPrefs.SetFloat("ScoreLevel02", 0);
        if(SceneManager.GetActiveScene().name=="Level03")
            PlayerPrefs.SetFloat("ScoreLevel03", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
        if(SceneManager.GetActiveScene().name=="Level01Easy" || SceneManager.GetActiveScene().name=="Level01Medium" || SceneManager.GetActiveScene().name=="Level01Hard")
            PlayerPrefs.SetFloat("ScoreLevel01", player.position.z);
        if(SceneManager.GetActiveScene().name=="Level02Easy" || SceneManager.GetActiveScene().name=="Level02Medium" || SceneManager.GetActiveScene().name=="Level02Hard")
            PlayerPrefs.SetFloat("ScoreLevel02", player.position.z);
        if(SceneManager.GetActiveScene().name=="Level03Easy" || SceneManager.GetActiveScene().name=="Level03Medium" || SceneManager.GetActiveScene().name=="Level03Hard")
            PlayerPrefs.SetFloat("ScoreLevel03", player.position.z);
    }

}
