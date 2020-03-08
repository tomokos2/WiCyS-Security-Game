using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start() {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0.0f, 0.0f)); 
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            transform.Translate(new Vector3(0.0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0.0f));
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f)
        {
            transform.Translate(new Vector3(0.0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0.0f));
        }
 Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
     	
 Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
 
 transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1,  maxScreenBounds.x - 1),Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
 
    }
}
