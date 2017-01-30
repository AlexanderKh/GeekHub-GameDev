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
        data.Add ("Mortal Combat", new Painting(
            "Mortal Combat",
            "TheSyanArt",
            "Mortal Kombat Scorpion Wallpaper"
        ));
        data.Add ("Nikola Tesla", new Painting(
            "Nikola Tesla",
            "vinartvin",
            "Nikola Tesla Art"
        ));
        data.Add ("Beatles", new Painting(
            "The Beatles",
            "vinartvin",
            "The Beatles Art"
        ));
        data.Add ("Speedpaint", new Painting(
            "Speed Paint #75",
            "Sylar113",
            "http://sylar113.deviantart.com/art/speedpaint-75-584565460"
        ));
    }

    public static Painting GetPaintingByKey (string key)
    {
        return (Painting) data [key];
    }
}
