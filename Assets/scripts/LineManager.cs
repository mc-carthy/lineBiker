using UnityEngine;

public class LineManager : MonoBehaviour {

    [SerializeField]
    private GameObject linePrefab;

    private Line currentLine;

	private void Update ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            GameObject newLine = Instantiate (linePrefab) as GameObject;
            currentLine = newLine.GetComponent<Line> ();
        }

        if (Input.GetMouseButtonUp (0))
        {
            currentLine = null;
        }

        if (currentLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            currentLine.UpdateLine (mousePos);
        }

    }

}
