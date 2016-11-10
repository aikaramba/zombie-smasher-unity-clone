using UnityEngine;
using System.Collections;

public class CrookedZombie : ZombieBehaviour {
    override protected void Start() {
        base.Start();
        movementVec = (GameController.GetRandomMovementTarget() - transform.position).normalized * movementSpeed;
        // going to random point 
        // (possibly diagonally towards the camera)
    }
}
