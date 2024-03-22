using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Movement mov;
    Camera cam;
    public Vector3 relativeDirection;
    private Vector3 forwardVector;
    private Vector3 rightVector;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        mov = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        relativeDirection = RelativeToCamera(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        mov.direction = relativeDirection;
    }
        
    Vector3 RelativeToCamera(Vector2 v)
    {

        //Calculate forward and right
        forwardVector = Vector3.Cross(-Vector3.up, cam.transform.right).normalized;
        rightVector = cam.transform.right;
        Vector3 temp = ((rightVector * v.x) + (forwardVector * v.y));

        return temp;
    }
}
