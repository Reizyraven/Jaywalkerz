using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    //variable
    public Button restartButt;
    public GameObject gameOverScreen;
    void Start()
    {
        restartButt = GameObject.Find("restartButt").GetComponent<Button>();
        restartButt.onClick.AddListener(restartGameSession);
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartGameSession(){
        SceneManager.LoadScene(2,LoadSceneMode.Single);
    }
}
