using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MovingScript
{

    public override void OnCollisionEnter (Collision collisionInfo) { //quando il cubo collide con qualcosa (es. pavimento) entro in questa funzione
        if(collisionInfo.collider.tag == "Player")
            GetComponent<Renderer>().material.color = new Color(0, 0, 80);
    }
    
}
