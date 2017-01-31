using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text closestPaintingLabel;
    public GameObject showMoreButton;
    public GameObject scrollView;
    public Text paintingInfoText;

    private Animator scrollViewAnimator;

    private ClosestPaintingCalculator closestPaintingCalculator;

    void Start ()
    {
        closestPaintingCalculator = GameObject.FindObjectOfType<ClosestPaintingCalculator> ();
        scrollViewAnimator = scrollView.GetComponent<Animator> ();
    }

    void Update ()
    {
        closestPaintingLabel.text = closestPaintingCalculator.GetClosestPaintingInfo ().name;
        var cpd = closestPaintingCalculator.GetClosestPaintingDistance ();
        if (cpd < 7.5f) {
            SafeSetActive (showMoreButton, true);
        } else {
            SafeSetActive (showMoreButton, false);
        }
    }

    public void OpenPaintingInfo ()
    {
        string paintingInfo = closestPaintingCalculator.GetClosestPaintingInfo ().GetFormattedDescription ();
        paintingInfoText.text = paintingInfo;
        scrollViewAnimator.SetBool ("hidden", false);
    }

    public void ClosePaintingInfo ()
    {
        scrollViewAnimator.SetBool ("hidden", true);
    }

    private void SafeSetActive (GameObject obj, bool active)
    {
        if (obj.activeSelf != active) {
            obj.SetActive (active);
        }
    }
}
