using UnityEngine;
using System.Collections;

public class ZombieCollector : MonoBehaviour {
	void Start () {
	    
	}
	void Update () {
	    
	}
    // catching and destroying zombies / adding score / removing lives
    void OnTriggerEnter(Collider col) {
        ZombieBehaviour zbT = col.GetComponent<ZombieBehaviour>();
        if (zbT != null) {
            if (zbT.GetType() == typeof(FriendlyZombie)) {
                GameController.AddScore(1); // adding score is zombie was friendly
            } else {
                GameController.SpendLives(1); // removing 1 llife if zombie was hostile
            }
            zbT.Kill(); // killing zombie
        }
    }
}
