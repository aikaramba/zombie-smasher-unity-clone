using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ZombieBehaviour : MonoBehaviour {
    public float movementSpeed = 1f;
    public GameObject bloodSplatterPrefab;
    protected Vector3 movementVec = Vector3.zero;

    virtual protected void Start () {
        movementVec = new Vector3(0f, 0f, -1f) * movementSpeed; // going straight towards the camera
    }
    virtual protected void Update() {
        transform.position += movementVec * Time.deltaTime; //moving our zombie
    }
    // main zombie click detection
    virtual protected void OnMouseDown() {
        if (!GameController.IsGameRunning()) return;
        GameController.AddScore(1);
        Kill();
    }
    // main kill function
    public void Kill() {
        if (bloodSplatterPrefab) // spawning blood splatter
            Instantiate(bloodSplatterPrefab, transform.position, Quaternion.Euler(new Vector3(90f,Random.Range(0f,360f),0f)));
        Destroy(this.gameObject); // destroying our zombie
    }
}
