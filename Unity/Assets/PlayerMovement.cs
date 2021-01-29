using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController PlayerController;
    public Vector3 moveDirection = Vector3.zero;
    public float gravity = 100f;


    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.isGrounded == true)
        {

        }
    }
}
