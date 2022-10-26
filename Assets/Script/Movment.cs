using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movment : MonoBehaviour
{
    public CharacterController controler;
    public Transform cam;

    public float speed = 6f;
    public float turnS = 0.1f;
    float turnSspeed;

    public float gravity = 20f;


    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveD = Vector3.zero;

        if (controler.isGrounded)
        {
            if (direction.magnitude >= 0.1f)
            {
                float rotasion = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotasion, ref turnSspeed, turnS);
                transform.rotation = Quaternion.Euler(0f, angel, 0f);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = 10f;
                }
                else
                {
                    speed = 6f;
                }
                moveD = Quaternion.Euler(0f, rotasion, 0f) * Vector3.forward;
                moveD.Normalize();
            }
        }
        moveD.y -= gravity * Time.deltaTime;
        controler.Move(moveD * speed * Time.deltaTime);

    }
}
