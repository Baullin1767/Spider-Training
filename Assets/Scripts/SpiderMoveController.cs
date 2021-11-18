using UnityEngine;

public class SpiderMoveController : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float speed = 1, speedRotation = 3;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * speedRotation, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float curSreed = speed * Input.GetAxis("Vertical");

        characterController.SimpleMove(forward * -curSreed);
        PlayAnimation();
    }

    void PlayAnimation() 
    {
       animator.SetFloat("Pos y", Input.GetAxis("Vertical"));
       animator.SetFloat("Pos x", Input.GetAxis("Horizontal"));
    }

}
