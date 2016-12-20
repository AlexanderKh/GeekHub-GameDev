﻿using UnityEngine;
using System.Collections;

public class CharacterFirstPersonController : MonoBehaviour
{

    public float speed = 10.0F;

    private GameObject cam;

    void Start ()
    {
        cam = GetComponentInChildren<Camera> ().gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update ()
    {
        if (Input.GetKeyDown ("escape"))
            Cursor.lockState = CursorLockMode.None;
        if (Input.GetButtonDown ("Fire1")) {
            Interact ();
        }
    }

    void FixedUpdate ()
    {
        MoveCharacter ();        
    }

    void MoveCharacter ()
    {
        int multiplier = Input.GetKey (KeyCode.LeftShift) ? 2 : 1;
        float translation = Input.GetAxis ("Vertical") * speed * multiplier;
        float straffe = Input.GetAxis ("Horizontal") * speed;
    
        transform.Translate (straffe, 0, translation);
    }

    void Interact ()
    {
        RaycastHit hit;
        if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 2)) {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag ("Interactive")) {
                go.BroadcastMessage ("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}