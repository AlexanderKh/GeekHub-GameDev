using UnityEngine;
using System.Collections;

public class SunFlareSwitcher : MonoBehaviour
{
    public GameObject sunFlare;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            sunFlare.SetActive (!sunFlare.activeSelf);
        }
    }
}
