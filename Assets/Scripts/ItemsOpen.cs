using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsOpen : MonoBehaviour

{
public GameObject door;
public Animator animator;
    void Interact()
    {
        animator.Play("Door_opening_animation");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
