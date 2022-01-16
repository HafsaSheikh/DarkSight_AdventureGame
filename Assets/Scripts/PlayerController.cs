using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Entity
{
    public int damage;
    CharacterController characterController;
    Animator animator;
    [SerializeField] float turnSpeed ;
    [SerializeField] float moveSpeed ;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject handBone;
    [SerializeField] float jumpSpeed ;
    [SerializeField] float gravity ;
    private Vector3 movingDirection = Vector3.zero;
    private int live = 3;
    bool dead;
    GameManager gameManager;
    bool isDamage;
    public Image[] lives = new Image[3];
    private void Awake()
    {
        //gameManager = GetComponent<GameManager>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        inventory.ItemUsed += Inventory_ItemUsed;
        inventory.ItemRemoved += Inventory_ItemRemoved;
    }
    private void Start()
    {
        GameVariables.checkpoint = new Vector3(-33, 5, -95);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (!dead)
        {
            MovePlayer();
            JumpPlayer();
        }
        if(live==0)
        {
            gameManager.GameOver();
        }

    }

    [SerializeField]
    float currentHealth;
    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

   

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);
        if (goItem.gameObject.CompareTag("Pistol"))
        {
            animator.SetBool("Firing", false);
        }
        goItem.transform.parent = null;
        

    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);

        goItem.transform.parent = handBone.transform;
        if(goItem.gameObject.CompareTag("Pistol"))
        {
            animator.SetBool("Firing", true);
        }
        

    }

   




    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }

    private void JumpPlayer()
    {
        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            movingDirection.y = jumpSpeed;
            animator.SetBool("Jump", true);
        }
        movingDirection.y -= gravity * Time.deltaTime;
        characterController.Move(movingDirection * Time.deltaTime);

    }


    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical)/*.normalized*/;
        //characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);
        animator.SetBool("Jump", false);
        animator.SetFloat("speed", vertical);
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if(vertical != 0)
        {
            characterController.SimpleMove(transform.forward * moveSpeed*vertical);
        }

        //if (movement.magnitude > 0)
        //{
        //    Quaternion newDirection = Quaternion.LookRotation(movement);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        //}

    }

    public override void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        PlayerDamage(true);
        
        if (currentHealth <= 0)
        // Die();
        {
            //dead = true;
            animator.SetBool("Death", true);
            animator.SetBool("idle", false);
            animator.SetBool("Firing", false);
            animator.SetBool("Jump", false);
            animator.SetFloat("speed", 0f);
            dead = true;
        }
    }
    public void PlayerDamage(bool damage)
    {
        Debug.Log("Hearts function Called");

        while (damage)
        {
            Debug.Log("loop Called");
            damage = !damage;
            lives[live-1].enabled = false;
            live--;
            Debug.Log("Lives"+live.ToString());
        }
       // Debug.Log("Lives" + live.ToString());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Enemy");
            if(live!=0)
            { Damage(1); }
            // gameManager.PlayerDamage(true);


        }


       if(other.CompareTag("Flag"))
        { gameManager.Success(); }

       if(other.CompareTag("Moon"))
        {
            Debug.Log("Triggered with Moon");
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Piece1", 1);
            Debug.Log(PlayerPrefs.GetInt("Piece1"));
        }
        if (other.CompareTag("DeathZone"))
        {
            Debug.Log("Collided with DeathZone");
            if (live != 0)
            {
                Damage(1);
                this.transform.position = GameVariables.checkpoint;


            }
        }

    }



}


