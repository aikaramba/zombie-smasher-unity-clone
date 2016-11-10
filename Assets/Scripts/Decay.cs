using UnityEngine;
using System.Collections;

public class Decay : MonoBehaviour {
    public float decayTime = 3f;
    private Vector3 decayMovementVec = Vector3.zero;
    
	void Start () {
        Invoke("Destroy", decayTime);
    }
	void Update () {
        decayMovementVec += new Vector3(0f, -0.01f, 0f); // acceleration
        transform.position += decayMovementVec * Time.deltaTime; // moving our corpse gameobject to its imminent demise
    }
    void Destroy() {
        Destroy(this.gameObject);
    }
}
