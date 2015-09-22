using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrapSpawner : MonoBehaviour {

    [SerializeField]
    private List<GameObject> spawnPoints;
    [SerializeField]
    private List<GameObject> trapPrefabs;
    private float timeToSpawnNextTrap = 2f;
    private bool allowedToGenerate = true;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update ()
    {

        timeToSpawnNextTrap -= 1f * Time.deltaTime;

        if (timeToSpawnNextTrap <= 0f && allowedToGenerate == true)
        {
            timeToSpawnNextTrap = 2f;
           spawnTrap(getRandomTrap(trapPrefabs), getTrapSpawnpoint);
        }
	}

    private GameObject spawnTrap(GameObject trap, Vector3 position)
    {

        return (GameObject)Instantiate(trap, position, Quaternion.identity);
    }

    private GameObject getRandomTrap(List<GameObject> availableTrap)
    {

            return availableTrap[Random.Range(0, trapPrefabs.Count)];
    }

    private Vector3 getTrapSpawnpoint
    {

        get
        {
            GameObject selectedSpawnPositionCarrier = spawnPoints[Random.Range(0, spawnPoints.Count)];

            return selectedSpawnPositionCarrier.transform.position;
        }
    }

    public bool allowedTogen
    {

        get
        {
            return allowedToGenerate;
        }
        set
        {
            allowedToGenerate = value;
        }
    }
    public float trapCooldown
    {

        get
        {
            return timeToSpawnNextTrap;
        }
        set
        {
            timeToSpawnNextTrap = value;
        }
    }
}
