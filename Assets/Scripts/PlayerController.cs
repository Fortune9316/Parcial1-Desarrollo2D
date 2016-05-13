using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float maxX;
    private float minX;

    public string actualColor;
    public int score;
    public int vida;
    public static PlayerController instance;
	void Start () {
        instance = this;
        score = 0;
        vida = 3;
        SetBoundsXY();
        print(maxX);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        int aux = Random.Range(1, 5);
        ChangeAnimation(aux);
        isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= minX)
        {
            transform.position -= new Vector3(5f * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= maxX)
        {
            transform.position += new Vector3(5f * Time.deltaTime, 0f, 0f);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeAnimation(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeAnimation(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeAnimation(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeAnimation(4);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == actualColor)
        {
            score += 100;
        }
        else
        {
            vida--;
            if(vida==0)
            {
                if(score > PlayerPrefs.GetInt("MaxScore",0))
                PlayerPrefs.SetInt("MaxScore", score);
                PlayerPrefs.SetInt("Score", score);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void ChangeAnimation(int aux)
    {        
        switch(aux)
        {
            case 1:
                animator.Play("Pink");
                actualColor = "Pink";
                break;
            case 2:
                animator.Play("Yellow");
                actualColor = "Yellow";
                break;
            case 3:
                animator.Play("Green");
                actualColor = "Green";
                break;
            case 4:
                animator.Play("Blue");
                actualColor = "Blue";
                break;
        }
    }

    void SetBoundsXY()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
}
