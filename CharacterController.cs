using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    static Animator anim;
    public float speed = 2.0f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
	}

    // Update is called once per frame
    void Update() {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
            if (translation != 0 || straffe !=0)
            {
                while (Input.GetButton("Fire2"))
                {
                    anim.SetBool("isRunning", true);
                    speed = 10.0f;
                }
                
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isIdle", false);
                
               
            }
            else
            {
                speed = 2.0f;
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", true);
            }

            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
	}
}
