using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private PlayerController me;
    private CameraController cam;
    // Start is called before the first frame update
    void Start()
    {
        me = FindObjectOfType<PlayerController>();
        me.transform.position = transform.position;

        cam = FindObjectOfType<CameraController>();
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
