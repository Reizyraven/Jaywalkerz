using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    //variables
    public int currentScore;
    public int kills;
    public GameObject gameUI;
    public GameObject gameOverScreen;
    public TextMeshProUGUI uiScore;
    public  TextMeshProUGUI uiKills;
    public TextMeshProUGUI uiFinalScore;
    public TextMeshProUGUI finalKills;
    public TextMeshProUGUI topScores;
    public GameObject player;


    void Start()
    {
        //gameUI = GameObject.Find("gameScreen");
        //gameOverScreenDebug = GameObject.Find("gameOverScreen");
        //uiScore = GameObject.Find("uiScore").GetComponent<TextMeshProUGUI>();
        //uiKills = GameObject.Find("uiKills").GetComponent<TextMeshProUGUI>();
        //uiFinalScore = GameObject.Find("").GetComponent<TextMeshProUGUI>();
        //finalKills = GameObject.Find("").GetComponent<TextMeshProUGUI>();
        //topScores = GameObject.Find("").GetComponent<TextMeshProUGUI>();


        //game reset 
        currentScore = 0;
        kills = 0;
        uiKills.text = kills.ToString();
        uiScore.text = currentScore.ToString();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseScore(int points){
        currentScore += points;
        kills += 1;
        uiKills.text = kills.ToString();
        uiScore.text = currentScore.ToString();

    }
    public void GameOver(){
        Debug.Log("Game Over");

        gameOverScreen.SetActive(true);
        gameUI.SetActive(false);
        player.SetActive(false);

        List<string> allScoreListString = new List<string>(PlayerPrefs.GetString("playerScores","").Split(','));
        Debug.Log(allScoreListString.Count);
        List<int> playerScores = new List<int>();
        foreach(string score in allScoreListString){
            playerScores.Add(int.Parse(score));
        }
        playerScores.Add(currentScore); 
        uiFinalScore.text = currentScore.ToString();
        finalKills.text = kills.ToString();
        playerScores.Sort();
        playerScores.Reverse();
        while(playerScores.Count >5){
            playerScores.Remove(playerScores[playerScores.Count - 1]);
        }

        topScores.text = string.Join("\n", playerScores);
        PlayerPrefs.SetString("playerScores", string.Join(",",playerScores)); 
    }
}