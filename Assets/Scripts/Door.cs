using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    void OnTriggerEnter() {
        var thedoor = GameObject.FindWithTag("SF_Door");
        thedoor.GetComponent<Animation>().Play("open");
    }

    void OnTriggerExit() {
        var thedoor = GameObject.FindWithTag("SF_Door");
        thedoor.GetComponent<Animation>().Play("close");
    }
}
