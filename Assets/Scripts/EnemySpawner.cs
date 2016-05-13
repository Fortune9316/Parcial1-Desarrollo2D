using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
    public List<GameObject> enemigos;

    private float cont;
    private float maxX;
    private float minX;
    void Start () {
        cont = 0f;
        SetBoundsXY();

    }
	
	// Update is called once per frame
	void Update () {
        cont += Time.deltaTime;
        if (cont >= 1f)
        {

                int aux = Random.Range(0, enemigos.Count);
                if (!enemigos[aux].activeInHierarchy)
                {
                    enemigos[aux].SetActive(true);
                    enemigos[aux].transform.position = new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
                }
            
            cont = 0f;
        }
	}
    
    void SetBoundsXY()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
}
