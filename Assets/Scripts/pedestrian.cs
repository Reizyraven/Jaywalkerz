using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class pedestrian : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject targetsParent;
    public List<GameObject> targets = new List<GameObject>(); 
    public int points;
    public GameObject player;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        targetsParent = GameObject.Find("Targets");
        foreach (Transform child in targetsParent.transform){
            targets.Add(child.gameObject);
        }
        player = GameObject.Find("Car");
        animator = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance == 0){
            int randomNum = Random.Range(0, targets.Count);
            agent.destination = targets[randomNum].transform.position;
        }
        if(Vector3.Distance(this.transform.position, player.transform.position) < 1.5f){
            animator.SetBool("run",true);
            Debug.Log("running");
        }
        else{
            animator.SetBool("run",false);
            Debug.Log("walking");
        }
    }
}
