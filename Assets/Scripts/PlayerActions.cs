using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
   public Ray ray;
   private float maxDistance = 2;
   public LayerMask layersToHit;
   public bool canInteract;

	public float health;
    public float damage;

   void Start()
   {
      ray = new Ray(transform.position, transform.forward);
      CheckForColliders();
   }

   void CheckForColliders()
   {
      if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layersToHit))
      {
         Debug.Log(hit.collider.gameObject.name + "was detected");
         canInteract = true;
      }
   }
   
   void Interaction()
   {
      if (canInteract = true && Input.GetKeyDown("E"))
         {
            //interact;
			//GetComponent.
			}

	}

 
}

  
