using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioScript : MonoBehaviour
{
    
    public static MenuAudioScript sgtAudio;

    void Awake () {
        if(sgtAudio!=null) {
            Destroy(gameObject);
        }
        else {
            sgtAudio=this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
