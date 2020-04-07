using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    public Collider2D door;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        door = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.enemiesList.Count > 0)
        {
            CloseDoor();
        }else if (GameManager.instance.enemiesList.Count <= 0)
        {
            OpenDoor();
        }
    }

   void OpenDoor()
    {
        animator.Play("DoorOpen");
        animator.Play("Opened");
        door.enabled = false;
    }

    void CloseDoor()
    {
        animator.Play("DoorLocked");
        animator.Play("Closed");
        door.enabled = true;
          
    }
}
