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

    private bool playerMoving;
    private Vector2 lastMove;

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

        playerMoving = false;

        float horMov = Input.GetAxisRaw("Horizontal");
        float vertMov = Input.GetAxisRaw("Vertical");

        if (horMov > 0.5f || horMov < -0.5f)
        {
            myBody.velocity = new Vector2(horMov * moveSpeed, myBody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(horMov, 0f);
        }

        if (vertMov > 0.5f || vertMov < -0.5f)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, vertMov * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, vertMov);
        }

        if (horMov < 0.5f && horMov > -0.5f)
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }

        if (vertMov < 0.5f && vertMov > -0.5f)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, 0f);
        }

        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("Move_X", horMov);
        anim.SetFloat("Move_Y", vertMov);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
     	
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1,  maxScreenBounds.x - 1),Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
 
    }
}
