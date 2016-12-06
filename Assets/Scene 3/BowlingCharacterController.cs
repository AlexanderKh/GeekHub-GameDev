using UnityEngine;
using System.Collections;

public class BowlingCharacterController : MonoBehaviour
{

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
        }
    }
}
