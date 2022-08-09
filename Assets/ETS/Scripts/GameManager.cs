using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public int life;
	public float timer;
	public int minScore;
	public int score;

	public int nextSceneLoad;
	public GameObject pausePanel;
	public GameObject winPanel;
	public GameObject losePanel;
	public GameObject life1, life2, life3, life4, life5;
	public GameObject text;
	public GameObject Story;

	public Slider timerSlider;
	public Text timerText;
	private bool stopTimer;
    // Start is called before the first frame update
	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}
		timerSlider.maxValue = timer;
		timerSlider.value = timer;
	}
	void Start()
    {
		pausePanel.SetActive(false);
		winPanel.SetActive(false);
		losePanel.SetActive(false);
		stopTimer = false;
		text.SetActive(false);
    }

    private void FixedUpdate()
    {
		if (Story.activeInHierarchy == false)
		{
			text.SetActive(true);
		}
		if (timer <= 0 && score >= minScore)
		{
			if(nextSceneLoad> PlayerPrefs.GetInt("levelAt"))
			{
				PlayerPrefs.SetInt("levelAt",nextSceneLoad);
			}
			SoundManager.instance.WinSFX();
			WinPanel();
			winPanel.SetActive(true);
		}
		else if (timer <= 0 && score < minScore)
		{
			GameOVer();
			losePanel.SetActive(true);
		}
		if (life <= 0)
        {
			life1.SetActive(false);
			life2.SetActive(false);
			life3.SetActive(false);
			life4.SetActive(false);
			life5.SetActive(false);
			GameOVer();
			losePanel.SetActive(true);
		}
		if (life == 5)
		{
			life1.SetActive(true);
			life2.SetActive(true);
			life3.SetActive(true);
			life4.SetActive(true);
			life5.SetActive(true);
		}
		if (life == 4)
		{
			life1.SetActive(true);
			life2.SetActive(true);
			life3.SetActive(true);
			life4.SetActive(true);
			life5.SetActive(false);
		}
		if (life == 3)
		{
			life1.SetActive(true);
			life2.SetActive(true);
			life3.SetActive(true);
			life4.SetActive(false);
			life5.SetActive(false);
		}
		if (life == 2)
		{
			life1.SetActive(true);
			life2.SetActive(true);
			life3.SetActive(false);
			life4.SetActive(false);
			life5.SetActive(false);
		}
		if (life == 1)
		{
			life1.SetActive(true);
			life2.SetActive(false);
			life3.SetActive(false);
			life4.SetActive(false);
			life5.SetActive(false);
		}
	}


    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
			timer -= Time.deltaTime;
			int minutes = Mathf.FloorToInt(timer / 60);
			int seconds = Mathf.FloorToInt(timer - minutes * 60);

			string TimeText = string.Format("{0:0}:{1:00}", minutes, seconds);
			timerSlider.value = timer;

			if (timer <= 0)
			{
				stopTimer = true;
			}
			if (stopTimer == false)
			{
				timerText.text = TimeText;

			}
        }

		

    }
	public void Paused()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
		SoundManager.instance.UIClickSFX();
	}
	public void Resume()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
		SoundManager.instance.UIClickSFX();
	}
	public void BackToMenu()
	{
		SoundManager.instance.UIClickSFX();
		Time.timeScale = 1;
		SceneManager.LoadScene("Menu");
	}
	public void BackLevelSelect()
	{
		SoundManager.instance.UIClickSFX();
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void nextLevel()
	{
		SoundManager.instance.UIClickSFX();
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	public void GameOVer()
    {
		SoundManager.instance.GameOverSFX();
		Time.timeScale = 0;
		Debug.Log("OverPanel");
    }

	public void WinPanel()
    {
		Time.timeScale = 0;
		Debug.Log("Win Panel");
    }
}
