using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text closestPaintingLabel;
    public GameObject showMoreButton;

    private ClosestPaintingCalculator closestPaintingCalculator;

    void Start ()
    {
        closestPaintingCalculator = GameObject.FindObjectOfType<ClosestPaintingCalculator> ();
    }

    void Update ()
    {
        closestPaintingLabel.text = closestPaintingCalculator.GetClosestPaintingInfo().name;
        var cpd = closestPaintingCalculator.GetClosestPaintingDistance ();
        if (cpd < 5f) {
            if (!showMoreButton.activeSelf) {
                showMoreButton.SetActive (true);
            }
        } else {
            if (showMoreButton.activeSelf) {
                showMoreButton.SetActive (false);
            }
        }
    }
}
