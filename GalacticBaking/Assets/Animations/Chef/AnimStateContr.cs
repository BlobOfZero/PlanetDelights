using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateContr : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isJumpingHash;
    int isJetpackHash;
    int turnLeftWalkHash;
    int turnRightWalkHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
        isJetpackHash = Animator.StringToHash("isJetpack");
        turnLeftWalkHash = Animator.StringToHash("turnLeftWalk");
        turnRightWalkHash = Animator.StringToHash("turnRightWalk");

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


        //Jumping Animation
        bool isJumping = animator.GetBool(isJumpingHash);
        bool jumpPressed = (Input.GetKey("space"));

        if (!isJumping && jumpPressed)
        {
            animator.SetBool("isJumping", true);
        }

        if (isJumping && !jumpPressed)
        {
            animator.SetBool(isJumpingHash, false);
        }
    
        //Jetpack Animation
        bool isJetpack = animator.GetBool(isJetpackHash);
        bool jetpackPressed = (Input.GetKey("q"));

        if (!isJetpack && jetpackPressed)
        {
            animator.SetBool("isJetpack", true);
        }

        if (isJetpack && !jetpackPressed)
        {
            animator.SetBool(isJetpackHash, false);
        }



    }
}
