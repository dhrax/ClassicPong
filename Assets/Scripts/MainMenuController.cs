using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    Button playButton;

    [SerializeField]
    Button settingsButton;

    [SerializeField]
    Button exitButon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlayButton(){
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickSettingsButton(){
        SceneManager.LoadScene("SettingsScene");
    }

    public void OnClickQuitbutton(){
        Application.Quit();
    }
}
