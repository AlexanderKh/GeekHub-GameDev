using UnityEngine;
using System.Collections;

public class SwitchStateButtonController : MonoBehaviour {

    public bool isScary = true;

    void interact() {
        isScary = !isScary;
        EventManager.fireChangeRoomState (isScary);
    }
}
