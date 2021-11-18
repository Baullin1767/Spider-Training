using UnityEngine;

public class SpiderMoveController : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float speed = 6.0f, speedRotation = 9.0f, jumpHeight = 8.0f, gravity = 20.0f;

    Vector3 moveDirection = Vector3.zero;

    bool push, die;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
       if (characterController.isGrounded && !die)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * speedRotation, 0);

            moveDirection = new Vector3(0,0,-Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (push)
            {
                moveDirection.y = jumpHeight;
            }
        }
        push = false;
        
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
        PlayAnimation();
        OnGround();
        Fall();
    }

    public void Push()
    {
       push = true;
    }

    void PlayAnimation() 
    {
       animator.SetFloat("Pos y", Input.GetAxis("Vertical"));
       animator.SetFloat("Pos x", Input.GetAxis("Horizontal"));
    }

    void OnGround()
    {
        if (characterController.isGrounded)
        {
            PlayAmimationBool("On Ground", true);
        }
        else
        {
            PlayAmimationBool("On Ground", false);
        }
    }


    void Fall() 
    {
        animator.SetFloat("Level Fall", transform.position.y);
        if (transform.position.y < -1)
        {
            PlayAmimationBool("Die", true);
            die = true; 
            moveDirection = Vector3.zero;
        }
        else
        {
            PlayAmimationBool("Die", false);
            die = false;
        }
    }

    void PlayAmimationBool(string nameBool, bool b)
    {
        animator.SetBool(nameBool, b);
    }
}
