using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour, ICollisionInterface
{
    private Vector3 startPosition;

    [SerializeField]
    private float frequency = 2f;

    [SerializeField]
    private float magnitude = 2f;

    [SerializeField]
    private float offset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    public virtual void OnCollisionEnter (Collision collisionInfo) {
        if(collisionInfo.collider.tag == "Player")
            GetComponent<Renderer>().material.color = new Color(100, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + transform.right * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }

}
