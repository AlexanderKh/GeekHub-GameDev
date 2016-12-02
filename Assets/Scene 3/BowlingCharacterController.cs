using UnityEngine;
using System.Collections;

public class BowlingCharacterController : MonoBehaviour {

    public Transform prefab;

    private Transform self;
    private Transform camera;

    void Start () {
        self = transform;
        camera = GetComponentInChildren<Transform> ();
    }

	void Update () {
        if (Input.GetButtonDown("Fire2")) {
            var o = Instantiate (prefab, self.position + camera.forward, Quaternion.identity) as Transform;
            var rb = o.GetComponent<Rigidbody> ();
            rb.AddForce (camera.forward * 500);
        }
	}
}
