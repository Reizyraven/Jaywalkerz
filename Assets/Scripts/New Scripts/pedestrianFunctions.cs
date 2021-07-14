using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pedestrianFunctions : MonoBehaviour
{
    //Stats
    public string Name;
    public int Points;

    //Components
    public NavMeshAgent AgentComponent;
    public Animator AnimatorComponent;
    public pedestrianFunctions PedestrianScriptComponent;

    // City Destinations
    public List<GameObject> Destinations;

    //Other
    public GameObject Player;
    public GameObject Ragdoll;

    //Data
    public float DistanceFromPlayer;



    // Start is called before the first frame update
    void Start()
    {
       //Get Components
       AgentComponent = this.gameObject.GetComponent<NavMeshAgent>();
       AnimatorComponent = this.gameObject.GetComponent<Animator>();
       PedestrianScriptComponent = this.gameObject.GetComponent<pedestrianFunctions>();

       //Get Destinations
       Destinations.AddRange(GameObject.FindGameObjectsWithTag("SpawnPositions"));

       //Get Objects in Map
       Player = GameObject.Find("Player");
       Ragdoll = GameObject.Find("Ragdoll");



    }

    // Update is called once per frame
    void Update()
    {
        //Variables to Update Every Frame
        DistanceFromPlayer = Vector3.Distance(Player.transform.position, this.gameObject.transform.position);

        //Walking to Random Destination
       if(AgentComponent.remainingDistance == 0){
           int randomDestination = Random.Range(0, Destinations.Count);
            AgentComponent.destination = Destinations[randomDestination].transform.position;
        }

        //Running from Player
        if(DistanceFromPlayer < 15.0f){
            AnimatorComponent.SetTrigger("Run");
            AgentComponent.speed = 7.0f;
        } else{
            AnimatorComponent.ResetTrigger("Run");
            AgentComponent.speed = 1.5f;
        }

    }

    void OnTriggerEnter(Collider collision){

         if(collision.name == "Player"){
            GameMechanics.IncreaseScore(Points);
            string PedestrianTypeLong = (this.name.TrimEnd('(', 'C', 'l','o','n','e', ')'));
            string PedestrianTypeShort = PedestrianTypeLong.Substring(0, PedestrianTypeLong.Length-3);;

            GameObject RagdollClone = Instantiate(Ragdoll, new Vector3(this.transform.position.x,this.transform.position.y+2,this.transform.position.z), Ragdoll.transform.rotation);
            foreach (Transform child in RagdollClone.transform)
            {
                //Debug.Log(child.name);
                if (child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(false);
                } else{
                    if (child.name == PedestrianTypeShort)
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }
            RagdollClone.transform.parent = Player.transform;
            Destroy(this.gameObject);
        }
    }


}