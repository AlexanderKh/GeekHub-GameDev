using UnityEngine;
using System.Collections;

public class MuseumCharacterController : MonoBehaviour
{
    public GameObject showMoreBtn;

    private bool inRange = false;
    private GameObject painting;

    void Start ()
    {
	
    }
	
    void Update ()
    {
	
    }

    void OnTriggerEnter (Collider col)
    {
        print (col.gameObject.name + " Enter");
        if (col.gameObject.CompareTag("Painting")) {
            inRange = true;
            painting = col.gameObject;
            showMoreBtn.SetActive (true);
        }
    }

    void OnTriggerExit (Collider col)
    {
        print (col.gameObject.name + " Exit");
        if (col.gameObject.CompareTag("Painting")) {
            inRange = false;
            painting = null;
            showMoreBtn.SetActive (false);
        }
    }
}
