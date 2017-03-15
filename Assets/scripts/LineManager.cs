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
    }

}
