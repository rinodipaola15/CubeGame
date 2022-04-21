using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour, ICollisionInterface
{   

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    float cubesPivotDistance;
    Vector3 cubesPivot;
    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    public Material material;
    public AudioSource sound;

    // Use this for initialization
    void Start() {

        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    }

    //public PlayerMovement movement;
    public GameManager1 gameManager1;

    public void OnCollisionEnter (Collision collisionInfo) { //quando il cubo collide con qualcosa (es. pavimento) entro in questa funzione
        //Debug.Log(collisionInfo.collider.name); //mi dice con quale oggetto il cubo sta collidendo
        if(collisionInfo.collider.tag == "Obstacle" || collisionInfo.collider.tag == "Enemy") { //se il cubo collide con un oggetto avente tag "Obstacle" o "Enemy" entro nell'if
            //Debug.Log("Ho colpito un ostacolo!");
            //movement.enabled = false; //quando il cubo collide con un oggetto il suo movimento viene disabilitato
            PlayerMovement.sgtMovement.enabled = false;
            sound.Play();
            explode();
            //PlayerPrefs.SetInt("numLives", (PlayerPrefs.GetInt("numLives")-1));
            //PlayerPrefs.Save();
            //Debug.Log(PlayerPrefs.GetInt("numLives"));
            FindObjectOfType<GameManager1>().EndGame();
            
        }
    }

    public void explode() {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++) {
            for (int y = 0; y < cubesInRow; y++) {
                for (int z = 0; z < cubesInRow; z++) {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders) {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z) {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        material = piece.GetComponent<Renderer>().material; 
        material.color=Color.red;
    }
}
