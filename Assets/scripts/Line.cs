using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Line : MonoBehaviour {

    private LineRenderer lineRen;
    private EdgeCollider2D edgeCol;

    private List<Vector2> points;
    private float pointDistanceThreshold = 0.1f;

    private void Awake ()
    {
        lineRen = GetComponent<LineRenderer> ();
        edgeCol = GetComponent<EdgeCollider2D> ();
    }

    public void UpdateLine (Vector2 point)
    {
        if (points == null)
        {
            points = new List<Vector2> ();
            SetPoint (point);
            return;
        }

        if (Vector2.Distance (points.Last (), point) > pointDistanceThreshold)
        {
            SetPoint (point);
        }
    }

    private void SetPoint (Vector2 point)
    {
        points.Add (point);

        lineRen.numPositions = points.Count;
        lineRen.SetPosition (points.Count - 1, point);

        if (points.Count > 1)
        {
            edgeCol.points = points.ToArray ();
        }
    }

}
