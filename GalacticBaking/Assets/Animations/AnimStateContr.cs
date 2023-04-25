using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateContr : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isJumpingHash;
    //int isJetpackRHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
        //isJetpackHash = Animator.StringToHash("isJetpack");

    }

    // Update is called once per frame
    void Update()
    {
        //Walking Animation
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = (Input.GetKey("w"));

        if (!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }


        //Walking Animation
        bool isJumping = animator.GetBool(isJumpingHash);
        bool jumpPressed = (Input.GetKey("r"));

        if (!isJumping && jumpPressed)
        {
            animator.SetBool("isJumping", true);
        }

        if (isJumping && !jumpPressed)
        {
            animator.SetBool(isJumpingHash, false);
        }
        
        //Jumpging Animation
         //bool isJumping = animator.GetBool(isJumpingHash);
         //bool jumpPressed = (Input.GetKey("r"));

        //if (!isJumping && jumpPressed)
        //{
        //animator.SetBool("isJumping", true);
        //}

        //if (isJumping && !jumpPressed)
        //{
        //    animator.SetBool(isJumpingHash, false);
        //}


        //Jetpack Animation
       // bool isJetpack = animator.GetBool(isJetpackHash);
        //bool jetpackPressed = (Input.GetKey("q"));

        //if (!isJetpack && jetpackPressed)
        //{
        //    animator.SetBool("isJetpack", true);
        //}

       // if (isJetpack && !jetpackPressed)
       // {
      ///      animator.SetBool(isJumpingHash, false);
       // }


    }
}
