using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    private Checkpoint [] checkpoints;
    private Player player;

    private int numCheckpoints;

    protected override void Awake ()
    {
        base.Awake ();
        player = GameObject.FindObjectOfType<Player> ();
        checkpoints = GameObject.FindObjectsOfType<Checkpoint> ();
        numCheckpoints = checkpoints.Length;
        Debug.Log (numCheckpoints);
    }

    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.R))
        {
            RestartLevel ();
        }
    }

    public void HitCheckpoint ()
    {
        numCheckpoints--;
        Debug.Log (numCheckpoints);
    }

    public void ExitHit ()
    {
        StartCoroutine (ExitHitRoutine ());
    }

    private IEnumerator ExitHitRoutine ()
    {
        if (numCheckpoints <= 0)
        {
            Debug.Log ("You win!");
            player.Freeze ();
            yield return new WaitForSeconds (3f);
            RestartLevel ();
        }
        yield return null;
    }

    private void RestartLevel ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
    }

}
