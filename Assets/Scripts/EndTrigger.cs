using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    
    //public GameManager1 gameManager1;

    void OnTriggerEnter() {
        //gameManager1.CompleteLevel();
        GameManager1.sgtGameManager.CompleteLevel();
    }

}
