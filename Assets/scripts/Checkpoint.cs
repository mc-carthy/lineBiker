using UnityEngine;

public class Checkpoint : MonoBehaviour {

    [SerializeField]
    private Sprite hitCheckPoint;

    private SpriteRenderer sprRen;
	private bool isHit;

    private void Awake ()
    {
        sprRen = GetComponent<SpriteRenderer> ();
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            sprRen.sprite = hitCheckPoint;
        }
    }

}
