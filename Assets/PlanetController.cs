using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour
{
    public string name = "Earth";

    private PlanetInfoTextController planetInfoTextCtrl;
    private int axisRotations;
    private int orbitRotations;

    void Start ()
    {
        GameObject planetInfoText = GameObject.FindGameObjectWithTag("Planet Info Text");
        planetInfoTextCtrl = planetInfoText.GetComponent<PlanetInfoTextController> ();
        axisRotations = 0;
        orbitRotations = 0;
    }
	
    void OnMouseDown ()
    {
        planetInfoTextCtrl.SelectPlanet (name);
        UpdatePlanetText ();
    }

    void IncrementAxisRotations ()
    {
        axisRotations++;
        UpdatePlanetText ();
    }

    void IncrementOrbitRotations ()
    {
        orbitRotations++;
        UpdatePlanetText ();
    }

    private void UpdatePlanetText ()
    {
        planetInfoTextCtrl.SetPlanetInfo (name, axisRotations, orbitRotations);
    }

}
