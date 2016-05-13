using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HudController : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> vidas;
    public Text text;
    public Text maxScore;
	void Start () {
        maxScore.text = "Max Score: " + PlayerPrefs.GetInt("MaxScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
        LifeControl();
        text.text = "Puntaje: " + PlayerController.instance.score;
	}

    void LifeControl()
    {
        switch(PlayerController.instance.vida)
        {
            case 3:
                vidas[0].SetActive(true);
                vidas[1].SetActive(true);
                vidas[2].SetActive(true);
                break;
            case 2:
                vidas[2].SetActive(false);
                break;
            case 1:
                vidas[2].SetActive(false);
                vidas[1].SetActive(false);
                break;
        }
    }
}
