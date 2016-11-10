using UnityEngine;
using System.Collections;

public class CharacterFirstPersonController : MonoBehaviour {

    public float speed = 10.0F;

	void Start () {
	   Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
	}

    void FixedUpdate () {
        moveCharacter();        
    }

    void moveCharacter () {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
    
        transform.Translate(straffe, 0, translation);
    }
}
