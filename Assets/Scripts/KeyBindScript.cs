using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{

    private Dictionary<string,KeyCode> keys = new Dictionary<string,KeyCode>();
    public Text Left, Right, Jump;
    private GameObject currentKey;
    private Color32 normal = new Color32(255, 255, 255, 255);
    private Color32 slected = new Color32(239, 116, 36, 255);

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "space")));

        Left.text = keys["Left"].ToString();
        Right.text = keys["Right"].ToString();
        Jump.text = keys["Jump"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keys["Left"])) {
            Debug.Log("Left");
        }
        if(Input.GetKeyDown(keys["Right"])) {
            Debug.Log("Right");
        }
        if(Input.GetKeyDown(keys["Jump"])) {
            Debug.Log("Jump");
        }
    }

    void OnGUI() {
        if(currentKey!=null) {
            Event e = Event.current;
            if(e.isKey) {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked) {
        if(currentKey!=null) {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = slected;
    }

    public void SaveKeys() {
        foreach (var key in keys)
        {
            Debug.Log(key.Key);
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
}
