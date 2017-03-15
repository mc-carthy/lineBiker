using UnityEngine;
using UnityEngine.UI;

public class LineManager : MonoBehaviour {

    [SerializeField]
    private GameObject [] linePrefabs;
    [SerializeField]
    private Text lineButtonText;

    private int currentLinePrefabIndex;
    private Line currentLine;

    private void Start ()
    {
        currentLinePrefabIndex = 0;
        lineButtonText.text = "Current Line : Regular Line";
    }

	private void Update ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            GameObject newLine = Instantiate (linePrefabs [currentLinePrefabIndex]) as GameObject;
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

        if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            CycleLineType ();
        }
    }

    public void CycleLineType ()
    {
        currentLinePrefabIndex++;

        if (currentLinePrefabIndex > (linePrefabs.Length - 1))
        {
            currentLinePrefabIndex = 0;
        }

        lineButtonText.text = "Current Line : " + linePrefabs [currentLinePrefabIndex].gameObject.name;
    }

}
