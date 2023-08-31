using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private bool canInteract;

    private CharacterController controller;
    private Animator mAnimator;
    //private Collider collider;
    
    void Start()
    {
        mAnimator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        //collider = GetComponentInChildren<CapsuleCollider>();
    }

    void Update()
    {
        Move();
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(AttackAnimation());
            Attack();
        }
    }
    
    //ATTACK
    private IEnumerator AttackAnimation()
    {
        mAnimator.SetLayerWeight(mAnimator.GetLayerIndex("Attack Layer"), 1);
        mAnimator.SetTrigger("TrAttack");

        yield return new WaitForSeconds(0.9f);
        mAnimator.SetLayerWeight(mAnimator.GetLayerIndex("Attack Layer"), 0);
    }

    private void Attack()
    {
        
    }
    
    //MOVEMENT
    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        if (moveDirection  == Vector3.zero)
        {
            Idle();
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Idle()
    {
        mAnimator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        mAnimator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        mAnimator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }
    
    //INVOKING INTERACTION

    void OnCollisionEnter(Collision collision)
    {
        canInteract = true;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
           if (canInteract = true && Input.GetKeyDown("E"))
                   {
                       Debug.Log("Interaction completed");
                       Interaction();
                   } 
        }
        
    }
   
    void Interaction()
    {
        //.
    }
}
