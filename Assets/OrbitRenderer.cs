using UnityEngine;
using System.Collections;

public class OrbitRenderer : MonoBehaviour
{

    public Material material;
    public int points = 100;
    public float width = 0.2f;
    public float radius = 3f;

    private LineRenderer lr;

    void Start ()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.material = material;
        lr.SetWidth (width, width);
        lr.SetVertexCount (points + 1);

        float fullCircle = 2 * Mathf.PI;
        float circlePartial = fullCircle / points;

        for(int i = 0; i <= points; i++) {
            float x, y;
            GetCartesian (radius, circlePartial * i, out x, out y);
            Vector3 position = new Vector3 (x, 0, y);
            lr.SetPosition(i, position);
        }
    }

    private void GetCartesian (float r, float theta, out float x, out float y)
    {
        x = r * Mathf.Cos (theta);
        y = r * Mathf.Sin (theta);
    }
}
