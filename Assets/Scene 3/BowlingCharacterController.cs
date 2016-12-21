using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BowlingCharacterController : MonoBehaviour
{
    public Text text;

    public Transform prefab;

    public Transform originalKegli;
    public Transform prefabKegli;

    private Transform self;
    private Transform camera;

    private Vector3 originalKegliPosition;
    private Quaternion originalKegliRotation;

    private float throwForce = 0;

    void Start ()
    {
        self = transform;
        camera = GetComponentInChildren<Transform> ();
        originalKegliPosition = originalKegli.position;
        originalKegliRotation = originalKegli.rotation;
    }

    void Update ()
    {
        if (Input.GetButton ("Fire2")) {
            throwForce += Time.deltaTime * 400;
        }
        if (Input.GetButtonUp ("Fire2")) {
            var o = Instantiate (prefab, self.position + camera.forward, Quaternion.identity) as Transform;
            var rb = o.GetComponent<Rigidbody> ();
            rb.AddForce (camera.forward * throwForce);
            throwForce = 0;
        }
        if (Input.GetButtonDown ("Fire3")) {
            Destroy (originalKegli.gameObject);
            originalKegli = Instantiate (prefabKegli, originalKegliPosition, originalKegliRotation) as Transform;
            foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball")) {
                Destroy (ball);
            }
            text.text = "";
        }
    }

    public void CalculateAndPrintScore() 
    {
        int kegliNumber = originalKegli.childCount;
        int fallenKegli = 0;
        for (int i = 0; i < kegliNumber; i++) {
            Transform keglya = originalKegli.GetChild (i);
            if (Vector3.Dot (keglya.up, Vector3.up) < 0.9F) {
                fallenKegli++;
            }
        }

        text.text = "Score is " + fallenKegli;
    }
}
