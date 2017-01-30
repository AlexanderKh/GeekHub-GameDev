using UnityEngine;
using System.Collections;

public class PlanetsDeselector : MonoBehaviour
{

    private PlanetInfoTextController planetInfoTextCtrl;

    void Start ()
    {
        GameObject planetInfoText = GameObject.FindGameObjectWithTag("Planet Info Text");
        planetInfoTextCtrl = planetInfoText.GetComponent<PlanetInfoTextController> ();
    }

    public void DeselectPlanets ()
    {
        BroadcastMessage ("DisableHalo", null, SendMessageOptions.DontRequireReceiver);
        planetInfoTextCtrl.DeselectPlanet ();
    }
}
