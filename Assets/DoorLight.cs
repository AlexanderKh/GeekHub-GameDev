using UnityEngine;
using System.Collections;

public class DoorLight : MonoBehaviour {
    public GameObject door;
    private GameObject player;
    private Light lt;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        lt = gameObject.GetComponent( typeof(Light) ) as Light;
	}
	
	// Update is called once per frame
	void Update () {
       float dist = Vector3.Distance(player.transform.position, door.transform.position);
       var lerpedColor = Color.Lerp(Color.red, Color.blue, (float) 1.0 / dist * 5);
       lt.color = lerpedColor;
	}
}
