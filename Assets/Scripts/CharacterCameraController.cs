using UnityEngine;
using System.Collections;

public class CharacterCameraController : MonoBehaviour {

    Vector2 lookAngle;
    public float sensitivity = 2.0f;

    public GameObject character;

	void Start () {
	   character = this.transform.parent.gameObject;
	}
	
	void Update () {
	   var md = new Vector2(Input.GetAxisRaw("Mouse X"), 
                            Input.GetAxisRaw("Mouse Y"));
       md *= sensitivity;
       lookAngle += md;

       transform.localRotation = Quaternion.AngleAxis(-lookAngle.y, Vector3.right);
       character.transform.localRotation = Quaternion.AngleAxis(lookAngle.x, character.transform.up);
	}
}
