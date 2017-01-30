using UnityEngine;
using System.Collections;

public class OrbitsSwitcher : MonoBehaviour
{
    public GameObject orbits;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O)) {
            orbits.SetActive (!orbits.activeSelf);
        }
    }
}
