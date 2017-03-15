using UnityEngine;

public class GameManager : Singleton<GameManager> {

	[SerializeField]
    private GameObject [] checkpoints;

    [SerializeField]
    private GameObject exit;

    private Player player;

    protected override void Awake ()
    {
        base.Awake ();
        player = GameObject.FindObjectOfType<Player> ();
    }

    public void GameOver ()
    {
        Debug.Log ("You win!");
        player.Freeze ();
    }

}
