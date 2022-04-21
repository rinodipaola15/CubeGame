using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement sgtMovement;

    void Awake () {
        if(sgtMovement!=null && sgtMovement!=this) {
            Destroy(gameObject);
            return;
        }
        sgtMovement=this;
    }

public Rigidbody rb; //in Unity trascino la proprietà Rigidbody in rb
public GameObject powerupEffect;
public GameObject powerupEffectSmall;
public GameObject powerupEffectBig;
public Transform player;

public float forwardForce = 2000f;
public float sidewaysForce = 500f;
public string left;
public string right;
public string jump;
private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

public bool cubeIsOnTheGround = true;

    void Start () {
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "space")));
    }

    // Update is called once per frame
    
    void FixedUpdate() //ho sostituito Update con FixedUpdate poiché lo stiamo usando per "giocare" con la fisica (es. quando il cubo incontra ostacoli)
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); //il cubo viene "lanciato"
        //la variabile forwardForce può essere modificata a run time

        //if(Input.GetKey("a")) {
        if(Input.GetKey(keys["Left"])) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } //se l'utente preme d il cubo si sposta a sinistra

        //if(Input.GetKey("d")) {
        if(Input.GetKey(keys["Right"])) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } //se l'utente preme d il cubo si sposta a destra

        if(rb.position.y < -1f) {
            FindObjectOfType<GameManager1>().EndGame();
        }

        if (Input.GetKey("space") && cubeIsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            cubeIsOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Ground") {
            cubeIsOnTheGround = true;
        }
    }

    public void AddEffectPowerUp() {
        GameObject powerupEffectCopy = Instantiate(powerupEffect, player.transform.position, transform.rotation);
        powerupEffectCopy.transform.parent = player.transform;
    }

    public void AddEffectPowerUpSmall() {
        GameObject powerupEffectCopySmall = Instantiate(powerupEffectSmall, player.transform.position, transform.rotation);
        powerupEffectCopySmall.transform.parent = player.transform;
    }

    public void AddEffectPowerUpBig() {
        GameObject powerupEffectCopyBig = Instantiate(powerupEffectBig, player.transform.position, transform.rotation);
        powerupEffectCopyBig.transform.parent = player.transform;
    }
}
