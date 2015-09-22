using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    [SerializeField]
    private Player player;
    [SerializeField]
    private MapGenerator mapper;
    [SerializeField]
    private TrapSpawner trapper;
    private int leftCounter = 0;
    private int rightCounter = 0;
    private float scoreCounter = 0f;
    private Text scoreText;
    private float deathCountdown = 5f;

	// Use this for initialization
	void Start () {

        getManagerComponents();
    }
	
	// Update is called once per frame
	void Update () {

        scoreText.text = (scoreCounter.ToString("F2") + "s");

        if (player.hasDied == false)
        {
            checkForInput();
        }
        checkPlayerState();
	}

    private void checkForInput()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) && rightCounter <= 0)
        {
            player.transform.position += new Vector3(0.8f, 0);
            rightCounter++;
            leftCounter--;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && leftCounter <= 0)
        {
            player.transform.position += new Vector3(-0.8f, 0);
            leftCounter++;
            rightCounter--;
        }
    }
    private void checkPlayerState()
    {

        if (player.hasDied == false)
        {
            scoreCounter += 1f * Time.deltaTime;
        }

        if (player.hasDied == true)
        {
            scoreText.text = "You Died!\n" + "You lasted " + Mathf.Round(scoreCounter) + " Seconds" + "\n \n Going back to menu in: " + Mathf.Round(deathCountdown);
            scoreText.transform.position = new Vector3(0, 0);
            mapper.setChunkGeneration = false;
            trapper.allowedTogen = false;
            deathCountdown -= 1f * Time.deltaTime;

            if (deathCountdown <= 0)
            {
                Application.LoadLevel("Main");
            }
        }
    }

    private void getManagerComponents()
    {
        mapper = GameObject.Find("ChunkManager").GetComponent<MapGenerator>();
        player = GameObject.Find("Player").GetComponent<Player>();
        trapper = GameObject.Find("TrapSpawner").GetComponent<TrapSpawner>();
        scoreText = GameObject.Find("Canvas").GetComponentInChildren<Text>();
    }
}
