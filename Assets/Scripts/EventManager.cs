using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    public delegate void ChangeRoomState(bool scary);
    public static event ChangeRoomState ChangeRoomStateEvent;

    public static void fireChangeRoomState(bool scary) {
        if (ChangeRoomStateEvent != null) {
            ChangeRoomStateEvent (scary);
        }
    }
}
