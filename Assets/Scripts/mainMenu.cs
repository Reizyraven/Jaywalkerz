using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public Button StartButton; 
    // Start is called before the first frame update
    void Start()
    {
        StartButton = GameObject.Find("startButton").GetComponent<Button>();
        StartButton.onClick.AddListener(StartButtonOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartButtonOnClick(){
        SceneManager.LoadScene("City",LoadSceneMode.Single);
    }
}
