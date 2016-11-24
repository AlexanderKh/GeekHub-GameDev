using UnityEngine;
using System.Collections;

public class LampController : MonoBehaviour {

	public float maxFlickeringTime = 0.75F;
	public float minFlickeringTime = 0.25F;

    public Color friendlyColor;
    public float friendlyIntensity;

	public GameObject lightObj;
    public GameObject lamp;

	private Light light;
    private Color lightColor;
    private float lightIntensity;
    private bool swayAndFlicker = true;

	private Rigidbody rb;
	private bool punched = false;

    void OnEnable() { EventManager.ChangeRoomStateEvent += RoomStateChangeHandler; }
    void OnDisable() { EventManager.ChangeRoomStateEvent -= RoomStateChangeHandler; }

    void RoomStateChangeHandler(bool scary) {
        swayAndFlicker = scary;
        print ("YOLO " + scary);
        if (scary) {
            foreach (Rigidbody rb in GetComponentsInChildren(typeof(Rigidbody))) {
                rb.angularDrag = 0F;
                rb.drag = 0F;
            }
            light.color = lightColor;
            light.intensity = lightIntensity;
            light.shadows = LightShadows.Soft;
            StartCoroutine (SwayAndFlicker ());
        } else {
            foreach (Rigidbody rb in GetComponentsInChildren(typeof(Rigidbody))) {
                rb.angularDrag = 1000F;
                rb.drag = 1000F;
            }
            light.color = friendlyColor;
            light.intensity = friendlyIntensity;
            light.enabled = true;
            light.shadows = LightShadows.None;
        }
    }

	void Start () {
        rb = lamp.GetComponent<Rigidbody> ();
		light = lightObj.GetComponent<Light> ();
        lightColor = light.color;
        lightIntensity = light.intensity;
        StartCoroutine (SwayAndFlicker());
	}

	IEnumerator SwayAndFlicker() {
        while (swayAndFlicker) {
            rb.AddForce ((Random.value - 0.5F) * 200, -1F, 0F);
			light.enabled = !light.enabled;
			yield return new WaitForSeconds (Random.Range(minFlickeringTime, maxFlickeringTime));
		}
	}
}
