using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionsBackButton : MonoBehaviour
{
    int mainVolume;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onClick() 
    {
        //Loads the Credits Scene
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
