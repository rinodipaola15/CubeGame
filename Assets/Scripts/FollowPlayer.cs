using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    void Start() {
        Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.position);
        transform.position = player.position + offset; //in questo modo la telecamera si sposta insieme al cubo
    }
}
