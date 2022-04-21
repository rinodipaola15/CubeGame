using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleAudioManager : MonoBehaviour
{

    static SingleAudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance!=null)
            Destroy(gameObject);
        else {
            instance = this;
                DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
