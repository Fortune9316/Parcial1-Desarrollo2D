using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    // Use this for initialization
    private float maxY;
    private float minY;
	void Start () {
        SetBoundsXY();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(0f, 5f * Time.deltaTime);
        if(transform.position.y <= minY)
        {
            gameObject.SetActive(false);
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
    void SetBoundsXY()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxY = bounds.y - 0.5f;
        minY = -bounds.y + 0.5f;
    }
}
