using UnityEngine;
using System.Collections;

public class SwitchStateButtonController : MonoBehaviour
{

    public bool isScary = true;

    void Interact ()
    {
        isScary = !isScary;
        GetComponentInChildren<Animation> ().Play ();
        EventManager.fireChangeRoomState (isScary);
    }
}
