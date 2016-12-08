using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClosestPaintingLabelController : MonoBehaviour
{
    private GameObject[] paintings;
    private GameObject player;

    private Text text;

    void Start ()
    {
        paintings = GameObject.FindGameObjectsWithTag ("Painting");
        player = GameObject.FindGameObjectWithTag ("Player");
        text = GetComponent<Text> ();
    }

    void Update ()
    {
        if (paintings.GetLength (0) == 0) {
            print ("bye");
            return;
        }
        GameObject closest = paintings [0];
        float closestDistance = GetDistance (closest, player);
        foreach (var painting in paintings) {
            float distance = GetDistance (painting, player);
            if (distance < closestDistance) {
                closest = painting;
                closestDistance = distance;
            }
        }

        text.text = closest.name;
    }

    float GetDistance (GameObject a, GameObject b)
    {
        var cuurentPaintingPosition = a.GetComponent<Transform> ().position;
        var lastClosestPaintingPosition = b.GetComponent<Transform> ().position;
        return Vector3.Distance (cuurentPaintingPosition, lastClosestPaintingPosition);
    }
}
