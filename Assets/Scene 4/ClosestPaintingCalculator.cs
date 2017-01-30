using UnityEngine;
using System.Collections;

public class ClosestPaintingCalculator : MonoBehaviour
{
    private GameObject[] paintings;
    private GameObject player;

    private GameObject closestPainting;
    private float closestDistance;

    void Start ()
    {
        paintings = GameObject.FindGameObjectsWithTag ("Painting");
        player = GameObject.FindGameObjectWithTag ("Player");
        closestPainting = paintings [0];
        closestDistance = GetDistance (closestPainting, player);
    }

    void Update ()
    {
        if (paintings.GetLength (0) == 0) {
            return;
        }
        closestDistance = GetDistance (closestPainting, player);
        foreach (var painting in paintings) {
            float distance = GetDistance (painting, player);
            if (distance < closestDistance) {
                closestPainting = painting;
                closestDistance = distance;
            }
        }
    }

    public GameObject GetClosestPaintingObject ()
    {
        return closestPainting;
    }

    public Painting GetClosestPaintingInfo ()
    {
        return PaintingsData.GetPaintingByKey (closestPainting.name);
    }

    public float GetClosestPaintingDistance ()
    {
        return closestDistance;
    }

    private float GetDistance (GameObject a, GameObject b)
    {
        var cuurentPaintingPosition = a.GetComponent<Transform> ().position;
        var lastClosestPaintingPosition = b.GetComponent<Transform> ().position;
        return Vector3.Distance (cuurentPaintingPosition, lastClosestPaintingPosition);
    }
}
