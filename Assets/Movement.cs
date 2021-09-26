using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    private float speed;
    private float jumpForce;
    public bool isGrounded = true;
    private bool isDead = false;

    public GameObject YouDied;
    public GameObject YouWin;
    public GameObject Restart;
    public Animator anim;
    public bool reload = false;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3.0f;
        jumpForce = 5.0f;
        anim.SetBool("isDead", false);
    }

    // Update is called once per frame
    public void Update()
    {
        

        if (anim.GetBool("isDead") == false && GetisDead() == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                player.transform.localScale = new Vector3(8.0f, 8.0f, 0.5f);
                player.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                player.transform.localScale = new Vector3(-8.0f, 8.0f, 0.5f);
                player.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }


        if (GetisDead() == true)
        {
            YouDied.SetActive(true);
            Restart.SetActive(true);
            YouWin.SetActive(false);
            anim.SetBool("isDead", true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                reload = true;
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

            }
        }

        if (player.transform.position.y <= -3.0f)
        {
            isDead = true;
        }

    }

    public bool GetisDead()
    {
        return isDead;
    }

    public void SetisDead(bool check)
    {
        isDead = check;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == ("Goal"))
        {
            YouWin.SetActive(true);
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
            isGrounded = true;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
         isGrounded = false;
        
    }
}
