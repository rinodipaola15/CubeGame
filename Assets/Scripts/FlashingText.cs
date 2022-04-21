using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{

    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;

        if(timer>=0.5) {
            GetComponent<Image>().enabled=true;
        }

        if(timer>=1.2) {
            GetComponent<Image>().enabled=false;
            timer=0;
        }        
    }
}
