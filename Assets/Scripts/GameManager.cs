using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    private PlatformDestroyer[] platforms;

    public ScoreManager scoreManager;

	// Use this for initialization
	void Start ()
    {
        playerStartPoint = thePlayer.transform.position;
        platformStartPoint = platformGenerator.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        scoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        thePlayer.transform.position = playerStartPoint;
        platforms = FindObjectsOfType<PlatformDestroyer>();
        for(var i=0; i< platforms.Length; i++)
        {
            platforms[i].gameObject.SetActive(false);
        }

        platformGenerator.position = platformStartPoint;

        thePlayer.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true; 

    }
}
