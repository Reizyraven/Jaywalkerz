using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{   //variable 
    public GameObject cloneMale;
    public GameObject cloneFemale;
    public GameObject cloneCat;
    public GameObject[] clones;
    public int randClone;
    public GameObject pedestrian;
    public Quaternion rotation;
    public GameObject[] pedestrians; 
    public int pedestrianCount;
    public GameObject[] navMeshPositions;
    public float randomPositionX;
    public float randomPositionY;
    public float randomPositionZ;
    public Vector3 randomPosition;
    public int randNum;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Quaternion(0,0,0,0);
        navMeshPositions = GameObject.FindGameObjectsWithTag("walkable");
    }

    // Update is called once per frame
    void Update()
    {   
        GameObject[] clones = new GameObject[]{cloneMale,cloneFemale,cloneCat};
        randClone = Random.Range(0,clones.Length);
        randNum = Random.Range(0,navMeshPositions.Length);
        randomPositionX = navMeshPositions[randNum].transform.position.x;
        randomPositionY = navMeshPositions[randNum].transform.position.y;
        randomPositionZ = navMeshPositions[randNum].transform.position.z;
        randomPosition = new Vector3(randomPositionX, randomPositionY, randomPositionZ);
        pedestrians = GameObject.FindGameObjectsWithTag("pedestrian");
        pedestrianCount = pedestrians.Length;
        if(pedestrianCount<20){
            pedestrian = Instantiate(clones[randClone],randomPosition,rotation);
        }
    }
}
