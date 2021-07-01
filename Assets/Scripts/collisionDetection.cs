using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class collisionDetection : MonoBehaviour
{
    //variables 
    public GameObject player;
    public GameObject restartButton;
    public GameObject gameOverScreen;
    public int currentScore; 
    public int kills;
    // Start is called before the first frame update
    void Start()
    { 

        if(this.transform.name == "building"){
            player = GameObject.Find("Default Player");
            restartButton.GetComponent<Button>().onClick.AddListener(restartButtonOnClick);

            if(gameOverScreen != null){
                gameOverScreen.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void restartButtonOnClick(){
        SceneManager.LoadScene("City", LoadSceneMode.Single);
    }
    void OnTriggerEnter(Collider collision){
        currentScore = int.Parse(GameObject.Find("currentScore").GetComponent<TextMeshProUGUI>().text);

        if(this.gameObject.CompareTag("building") && collision.name == "Car"){
            Debug.Log("Collision");
            gameOverScreen.SetActive(true);
            player.GetComponent<CharacterController>().enabled = false;
            GameObject.Find("previousScore").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("lastSessionScore", 0).ToString();
            GameObject.Find("currentScore").SetActive(false);
            GameObject.Find("score").GetComponent<TextMeshProUGUI>().text = currentScore.ToString();
            PlayerPrefs.SetInt("lastSessionScore", currentScore);
            
        }
        if(this.gameObject.CompareTag("pedestrian") && collision.name == "Car"){
            Debug.Log("Collision");
            int points = this.GetComponent<pedestrian>().points;
            currentScore += points;
            kills +=1;
            GameObject.Find("currentScore").GetComponent<TextMeshProUGUI>().text = currentScore.ToString();
            Destroy(this.gameObject);
        } 
    }
}
