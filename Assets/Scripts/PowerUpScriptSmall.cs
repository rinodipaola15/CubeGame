using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScriptSmall : MonoBehaviour, ISoundInterface
{
    public GameObject pickupEffectSmall;
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
        Instantiate(pickupEffectSmall, transform.position, transform.rotation);
        
        //Apply effect to the player (for 5 seconds)
        player.transform.localScale = player.transform.localScale / 1.7f;
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        PlaySound();
        movement.AddEffectPowerUpSmall();
        PlayerPrefs.SetString("powerup", "POWER UP ACTIVATED!");
        yield return new WaitForSeconds(5);
        player.transform.localScale = player.transform.localScale * 1.7f;
        PlayerPrefs.SetString("powerup", "");
        PlayerPrefs.Save();
        
        //Remove power up object
        Destroy(gameObject);
    }
}