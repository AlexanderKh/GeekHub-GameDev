using UnityEngine;
using System.Collections;

public class BowlingCharacterController : MonoBehaviour {

    public Transform prefab;

	void Update () {
        if (Input.GetButtonDown("Fire2")) {
            Instantiate (prefab, Vector3.zero, Quaternion.identity);
        }
	}
}
