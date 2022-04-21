using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScriptFast : MonoBehaviour, ISoundInterface
{
    public GameObject pickupEffect;
    public AudioSource powerUpSound;

    public void PlaySound () {
        powerUpSound.Play();
    }

    void OnTriggerEnter (Collider other) {
        if(other.GetComponent<Collider>().tag == "Player") {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup (Collider player) {
        //Debug.Log("Power up picked up!");

        //Spawn a effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        
        //Apply effect to the player (for 5 seconds)
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        movement.forwardForce = movement.forwardForce * 1.3f;
        PlaySound();
        movement.AddEffectPowerUp();
        PlayerPrefs.SetString("powerup", "POWER UP ACTIVATED!");
        yield return new WaitForSeconds(5);
        movement.forwardForce = movement.forwardForce / 1.3f;
        PlayerPrefs.SetString("powerup", "");
        PlayerPrefs.Save();

        //Remove power up object
        Destroy(gameObject);
    }
}