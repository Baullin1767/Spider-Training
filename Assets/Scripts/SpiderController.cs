using UnityEngine;

public class SpiderController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (animator != null)
        {
            float posY = Input.GetAxis("Vertical");
            float posX = Input.GetAxis("Horizontal");

            animator.SetFloat("Pos y", posY);
            animator.SetFloat("Pos x", posX);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("Attack");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
            } 
        }
    }
}
