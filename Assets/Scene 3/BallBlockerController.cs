using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BallBlockerController : MonoBehaviour
{
    private bool isDown = true;
    private float downY;
    private float upY;

    void Start ()
    {
        downY = transform.position.y;
        upY = downY + 1;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            isDown = !isDown;
            if (isDown) {
                transform.DOMoveY (downY, 1);
            } else {
                transform.DOMoveY (upY, 1);
            }
        }
    }
}
