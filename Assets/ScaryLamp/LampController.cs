using UnityEngine;
using System.Collections;

public class LampController : MonoBehaviour {

	public float maxFlickeringTime = 0.75F;
	public float minFlickeringTime = 0.25F;

	public GameObject lightObj;

	private Light light;
	private Rigidbody rb;
	private bool punched = false;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		light = lightObj.GetComponent<Light> ();
		StartCoroutine (SwitchLight());
	}

	IEnumerator SwitchLight() {
		while (true) {
			light.enabled = !light.enabled;
			yield return new WaitForSeconds (Random.Range(minFlickeringTime, maxFlickeringTime));
		}
	}

	void FixedUpdate () {
		if (transform.eulerAngles.x >= 90F && !punched) {
			punched = true;
			rb.AddForce (100F, -5F, 0F);
		}
		if (transform.eulerAngles.x <= 90F && punched) {
			punched = false;
		}
	}
}
