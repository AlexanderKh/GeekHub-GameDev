using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlanetInfoTextController : MonoBehaviour
{

    private Text text;
    private string selectedPlanet;
    private Button button;

    void Start ()
    {
        text = GetComponent<Text> ();
        button = GetComponentInChildren<Button> ();
        button.gameObject.SetActive (false);
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
        button.gameObject.SetActive (true);
    }

    public void DeselectPlanet ()
    {
        button.gameObject.SetActive (false);
        selectedPlanet = null;
        text.text = "";
    }
}
