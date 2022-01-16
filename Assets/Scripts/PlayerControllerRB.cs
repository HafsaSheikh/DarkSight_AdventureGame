using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRB : Entity
{
    public int damage;
    Rigidbody playerRb;
    Animator animator;
    [SerializeField] float turnSpeed = 5;
    [SerializeField] float moveSpeed = 100;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject handBone;
    [SerializeField] float jumpSpeed = 200.0f;
    //[SerializeField] float gravity = 10.0f;
    private Vector3 movingDirection = Vector3.zero;




    private void Awake()
    {
        //characterController = GetComponent<CharacterController>();
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        inventory.ItemUsed += Inventory_ItemUsed;
        inventory.ItemRemoved += Inventory_ItemRemoved;
    }
   
    void Update()
    {
        MovePlayer();
        JumpPlayer();

    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0, 0, vertical);
        playerRb.velocity= new Vector3(horizontal*moveSpeed, playerRb.velocity.y, vertical*moveSpeed);
        animator.SetBool("Jump", false);
        animator.SetFloat("speed", movement.magnitude);
        
        
        
        
        //if (movement.magnitude > 0)
        //{
        //    Quaternion newDirection = Quaternion.LookRotation(movement);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        //}
    }

    private void JumpPlayer()
    {
        if (/*characterController.isGrounded &&*/ Input.GetButton("Jump"))
        {
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            animator.SetBool("Jump", true);
        }

    }
    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);

        goItem.transform.parent = null;


    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);

        goItem.transform.parent = handBone.transform;



    }

    private void OnCollisionEnter(Collision collision)
    {
        IInventoryItem item = collision.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }

   
}
