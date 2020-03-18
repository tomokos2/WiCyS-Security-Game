using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public bool canMove;

    private Animator anim;
    private Rigidbody2D myBody;
    // Start is called before the first frame update

    private static bool playerExists;
    void Start() {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            myBody.velocity = Vector2.zero;
            return;
        }

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < 0.5f)
        {
            //transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0.0f, 0.0f)); 
            myBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < 0.5f)
        {
            //transform.Translate(new Vector3(0.0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0.0f));
            myBody.velocity = new Vector2(myBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, 0f);
        }

        anim.SetFloat("Move_X", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Move_Y", Input.GetAxisRaw("Vertical")); 

        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
     	
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1,  maxScreenBounds.x - 1),Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
 
    }
}
