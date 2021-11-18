using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttackController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayAmimationBool("Attack", true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            PlayAmimationBool("Bite", true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayAmimationBool("Spit", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAmimationBool("Jump", true);
        }

    }

    public void CanMove(){ animator.SetBool("Can Move", true); }
    public void CanNotMove(){ animator.SetBool("Can Move", false); }

    public void Attack() { PlayAmimationBool("Attack", false); }
    public void Bite() { PlayAmimationBool("Bite", false); }
    public void Spit() { PlayAmimationBool("Spit", false); }
    public void Jump() { PlayAmimationBool("Jump", false); }

    void PlayAmimationBool(string nameBool, bool b)
    {
        animator.SetBool(nameBool, b);
    }
}
