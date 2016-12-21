using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public GameObject player;

    private bool collided = false;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    void OnCollisionEnter (Collision col)
    {
        if (!collided && col.gameObject.name.StartsWith("pin")) {
            collided = true;
            Invoke("CalculateAndPrintScore", 5);
        }
    }

    void CalculateAndPrintScore ()
    {
        player.SendMessage ("CalculateAndPrintScore");
    }
}
