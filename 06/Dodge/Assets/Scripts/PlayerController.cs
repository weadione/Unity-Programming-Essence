using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Rigidbody playerRigdbody;
    //public float speed = 8f;

    const float Gravity = 9.81f;
    public float gravityScale = 1.0f;


    private void Start()
    {
        //playerRigdbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        /*float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xspeed = speed * xInput;
        float yspeed = speed * yInput;

        Vector3 newVlelocity = new Vector3(xspeed, 0, yspeed);
        playerRigdbody.velocity = newVlelocity;*/

        Vector3 vector = new Vector3();

        if (Application.isEditor)
        {
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            if(Input.GetKey("z"))
            {
                vector.y = 1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }
        }
        else
        {
            vector.x = Input.acceleration.x;
            vector.y = Input.acceleration.y;
            vector.z = Input.acceleration.z;
        }

        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManeger = FindObjectOfType<GameManager>();
        gameManeger.EndGame();
    }
}
