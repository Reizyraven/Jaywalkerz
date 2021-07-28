using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pedestrianSpawn : MonoBehaviour
{
    //Variables
    public List<GameObject> NPCTemplates;
    public GameObject NPCCloneFolder;
    public GameObject SpawnObject;
    public List<GameObject> SpawnPositions;
    public int MaxPedestrians;

    // Start is called before the first frame update
    void Start()
    {
        //Create NPC Template Dictionary
        SpawnObject = GameObject.Find("Spawn");
        NPCCloneFolder = GameObject.Find("Pedestrians");
        foreach (Transform child in SpawnObject.transform)
            {
                NPCTemplates.Add(child.gameObject);
            }

        //Set Pedestrian Spawn Limit
        MaxPedestrians = 50;

        //Collect All Spawn Positions
        SpawnPositions.AddRange(GameObject.FindGameObjectsWithTag("SpawnPositions"));

        //Instantiate NPCs in World to Limit Loop
        for (int i = 0; i < MaxPedestrians; i += 1) {
            int randomNPC = Random.Range(0,NPCTemplates.Count);
            int randomPosition = Random.Range(0,SpawnPositions.Count);
            GameObject spawnedNPC = Instantiate(NPCTemplates[randomNPC], SpawnPositions[randomPosition].transform.position, Quaternion.identity);
            spawnedNPC.transform.parent = NPCCloneFolder.transform;
            spawnedNPC.gameObject.GetComponent<NavMeshAgent>().enabled = true;
            spawnedNPC.gameObject.GetComponent<Animator>().enabled = true;
            spawnedNPC.gameObject.GetComponent<pedestrianFunctions>().enabled = true;


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
