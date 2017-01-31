using UnityEngine;
using System.Collections;

public class Scene5Controls : MonoBehaviour
{
    public GameObject orbits;
    public GameObject sunFlare;
	
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O)) {
            orbits.SetActive (!orbits.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            sunFlare.SetActive (!sunFlare.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            Application.LoadLevel ("Scene 1");
        }
    }
}
