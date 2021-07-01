using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pauseMenu : MonoBehaviour
{   
    //variables 
    public float mainVolume;
    public Slider mainVolSlider;
    public GameObject pauseMenuObj;

    // Start is called before the first frame update
    void Start()
    {
        mainVolSlider = GameObject.Find("Slider").GetComponent<Slider>();
        mainVolSlider.onValueChanged.AddListener(delegate{volSlider();});
        AudioListener.volume = 0.25f;
        mainVolSlider.value = 0.25f;
        //pauseMenuObj = GameObject.Find("Pause Menu");
        pauseMenuObj.SetActive(false);
    }
    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pauseMenuObj.activeSelf){
                pauseMenuObj.SetActive(false);
        }else{
            pauseMenuObj.SetActive(true);
        } 
    }
    }
    public void exit(){
        Application.Quit();
    }
    public void resume(){
        GameObject.Find("Pause Menu").SetActive(false);
    }

    public void volSlider(){
        mainVolume = mainVolSlider.value;
        Debug.Log(mainVolSlider.value);
        AudioListener.volume = mainVolSlider.value;
    }
}
