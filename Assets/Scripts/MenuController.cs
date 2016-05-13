using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    // Use this for initialization
    public Button playBtn;
	void Start () {
        playBtn.onClick.AddListener(() => PlayGame());
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
