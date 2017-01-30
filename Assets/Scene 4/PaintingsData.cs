using UnityEngine;
using System.Collections;

public class PaintingsData : MonoBehaviour
{
    private static Hashtable data;

    static PaintingsData ()
    {
        data = new Hashtable ();
        data.Add ("Cherkasy Bridge", new Painting(
            "Cherkasy Bridge",
            "Alex Khomchenko",
            "I took this photo at the CherITy fest 2015"
        ));
    }

    public static Painting GetPaintingByKey (string key)
    {
        return (Painting) data [key];
    }
}
