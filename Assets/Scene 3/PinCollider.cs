using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCollider : MonoBehaviour
{

    public Text text;

    void Start ()
    {
	    
    }

    void Update ()
    {
	
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.collider.isTrigger) {
            if (col.gameObject.name == "Road") {
                text.text = "falllen";
            }
        }
    }
}
