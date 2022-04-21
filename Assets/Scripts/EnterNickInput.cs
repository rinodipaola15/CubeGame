using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterNickInput : MonoBehaviour
{
    public string nickname;
    public GameObject inputField;
    
    public void StartGame() {
        nickname = inputField.GetComponent<Text>().text;
        PlayerPrefs.SetString("nickname", nickname);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
