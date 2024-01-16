using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float horizentalinput;
 

    public float speed = 20;
    private int limit = 20;
    public GameObject projectilePrefab;

 



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizentalinput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * horizentalinput*speed);
        if(horizentalinput != 0)
        {
            animator.SetFloat("Speed_f", 0.5f);
        }
        

        //too left
        if (transform.position.x < -limit )
         {
            transform.position = new Vector3(-limit, transform.position.y, transform.position.z);
         }
        //too right
        if(transform.position.x > limit) 
          {
             transform.position = new Vector3(limit,transform.position.y, transform.position.z);
          }

        // Launch a projectile from the player 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  分別為 (物件, 位置, 面向的角度)
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }





    }
}
