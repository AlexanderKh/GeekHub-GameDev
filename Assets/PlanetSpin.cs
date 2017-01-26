using UnityEngine;
using System.Collections;

public class PlanetSpin : MonoBehaviour
{

    public float speed = 1f;

    void Start ()
    {
	
    }
	
    void Update ()
    {
        Quaternion rotation = transform.rotation;
        Vector3 angles = rotation.eulerAngles;
        angles.y += speed;
        rotation.eulerAngles = angles;
        transform.rotation = rotation;
    }
}
