using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
    void OnTriggerEnter() {
        Application.LoadLevel ("Scene 2");
    }
}