using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlanetInfoTextController : MonoBehaviour
{

    private Text text;
    private string selectedPlanet;

    void Start ()
    {
        text = GetComponent<Text> ();
    }

    public void SetPlanetInfo (string name, int axisRotations, int orbitRotations) 
    {
        if (name == selectedPlanet) {
            text.text = string.Format("{0}\nRotations: {1}\nOrbit Rotations: {2}", name, axisRotations, orbitRotations);
        }
    }

    public void SelectPlanet (string name)
    {
        selectedPlanet = name;
    }
}
