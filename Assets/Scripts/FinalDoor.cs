using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
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
        if (GameManager.instance.spawnersList.Count >= 1)
        {
            //CloseDoor();
            animator.Play("FinalDoorClose");
            animator.Play("FinalDoorClosed");
            door.enabled = true;
        }
        else if (GameManager.instance.spawnersList.Count == 0)
        {
            //OpenDoor();
            animator.Play("FinalDoorOpen");
            animator.Play("FinalDoorOpened");
            door.enabled = false;
        }
    }

    void OpenDoor()
    {
        animator.Play("FinalDoorOpen");
        animator.Play("FinalDoorOpened");
        door.enabled = false;
    }

    void CloseDoor()
    {
        animator.Play("FinalDoorClose");
        animator.Play("FinalDoorClosed");
        door.enabled = true;
    }
}
