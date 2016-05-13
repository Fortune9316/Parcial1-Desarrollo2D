using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    // Use this for initialization
    public Button playBtn;
    public Button backBtn;
    public Text scoreTxt;
	void Start () {
        playBtn.onClick.AddListener(() => PlayGame());
        backBtn.onClick.AddListener(() => BackGame());
        scoreTxt.text = "Score" + PlayerPrefs.GetInt("Score");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    void BackGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
