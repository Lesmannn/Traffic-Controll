using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu Panel List")]
    //public GameObject MainPanel;
    public GameObject OptionPanel;
    public GameObject CreditPanel;
    // Start is called before the first frame update
    void Start()
    {
        //MainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        CreditPanel.SetActive(false);
    }		

    public void BackButton()
    {
        //MainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        CreditPanel.SetActive(false);
		SoundManager.instance.UIClickSFX();
    }

    public void StartButton()
    {
		SoundManager.instance.UIClickSFX();
        SceneManager.LoadScene("LevelSelect");

    }
    public void ExitGame()
    {
		SoundManager.instance.UIClickSFX();
        Application.Quit();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
