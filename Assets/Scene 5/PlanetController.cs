using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour
{
    public string name = "Earth";
    public float speed = 1f;

    private GameObject sun;
    private PlanetInfoTextController planetInfoTextCtrl;
    private int axisRotations;
    private int orbitRotations;
    private float angle;
    private int sign;
    private Behaviour halo;

    void Start ()
    {
        GameObject planetInfoText = GameObject.FindGameObjectWithTag("Planet Info Text");
        planetInfoTextCtrl = planetInfoText.GetComponent<PlanetInfoTextController> ();
        sun = GameObject.FindGameObjectWithTag ("Sun");
        axisRotations = 0;
        orbitRotations = 0;
        angle = 0f;
        sign = (speed >= 0) ? 1 : -1;
        halo = (Behaviour) GetComponent ("Halo");
        DisableHalo ();
    }

    void Update ()
    {
        transform.RotateAround (sun.transform.position, Vector3.up, speed);
        angle += speed;
        if ((angle * sign) > 360f) {
            IncrementOrbitRotations ();
            angle -= 360 * sign;
        }
    }
	
    void OnMouseDown ()
    {
        GetComponentInParent<PlanetsDeselector> ().DeselectPlanets ();
        planetInfoTextCtrl.SelectPlanet (name);
        UpdatePlanetText ();
        EnableHalo ();
    }

    public void IncrementAxisRotations ()
    {
        axisRotations++;
        UpdatePlanetText ();
    }

    public void IncrementOrbitRotations ()
    {
        orbitRotations++;
        UpdatePlanetText ();
    }

    public void EnableHalo ()
    {
        halo.enabled = true;
    }

    public void DisableHalo ()
    {
        halo.enabled = false;
    }

    private void UpdatePlanetText ()
    {
        planetInfoTextCtrl.SetPlanetInfo (name, axisRotations, orbitRotations);
    }

}
