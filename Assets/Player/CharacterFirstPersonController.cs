using UnityEngine;
using System.Collections;

public class CharacterFirstPersonController : MonoBehaviour {

    public float speed = 10.0F;

    private GameObject cam;
    private Vector3 v;

	void Start () {
        cam = GetComponentInChildren<Camera> ().gameObject;
	    Cursor.lockState = CursorLockMode.Locked;
        v = cam.transform.forward;
	}
	
	void Update () {
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
        if (Input.GetButtonDown("Fire1")) {
            interact ();
            v = cam.transform.forward;
        }
        Debug.DrawRay (cam.transform.position, v * 10);
	}

    void FixedUpdate () {
        moveCharacter();        
    }

    void moveCharacter () {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
    
        transform.Translate(straffe, 0, translation);
    }

    void interact() {
        RaycastHit hit;


        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 2)) {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("Interactive")) {
                go.BroadcastMessage ("interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
