using UnityEngine;
using System.Collections;

public class CharacterFirstPersonController : MonoBehaviour
{

    public float speed = 0.5F;
    public float sensitivity = 2.0F;

    private Vector2 lookAngle;
    private GameObject camera;
    private GameObject player;

    void Start ()
    {
        camera = GetComponentInChildren<Camera> ().gameObject;
        player = this.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space)) {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyUp (KeyCode.Space)) {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetButtonDown ("Fire1")) {
            Interact ();
        }
    }

    void FixedUpdate ()
    {
        MoveCharacter ();
        if (Cursor.lockState == CursorLockMode.Locked) {
            RotateCamera ();
        }
    }

    void MoveCharacter ()
    {
        int multiplier = Input.GetKey (KeyCode.LeftShift) ? 2 : 1;
        float translation = Input.GetAxis ("Vertical") * speed * multiplier;
        float straffe = Input.GetAxis ("Horizontal") * speed;
    
        player.transform.Translate (straffe, 0, translation);
    }

    void RotateCamera ()
    {
        var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), 
            Input.GetAxisRaw ("Mouse Y"));
        md *= sensitivity;
        lookAngle += md;

        camera.transform.localRotation = Quaternion.AngleAxis (-lookAngle.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis (lookAngle.x, player.transform.up);
    }

    void Interact ()
    {
        RaycastHit hit;
        if (Physics.Raycast (camera.transform.position, camera.transform.forward, out hit, 2)) {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag ("Interactive")) {
                go.BroadcastMessage ("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
