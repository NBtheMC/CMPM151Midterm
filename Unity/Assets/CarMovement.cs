using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private CharacterController controller;
    
    public float speed;
    public float moveSmoothTime = .3f;
    public float steering;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetDir = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        //normalize and smooth vector
        targetDir.Normalize();

        if(Input.GetAxisRaw("Horizontal") > 0) {
        	transform.Rotate(0f, 0.5f, 0f);
        } else if(Input.GetAxisRaw("Horizontal") < 0) {
        	transform.Rotate(0f, -0.5f, 0f);
        }

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed * Time.deltaTime;

        controller.Move(velocity);

        OSCHandler.Instance.SendMessageToClient("pd", "/unity/velocity", velocity.magnitude * 10);
    }

}