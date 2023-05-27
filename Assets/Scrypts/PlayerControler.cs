using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float speed = 4.0f;
    [SerializeField] float jumpForce = 10.5f;
    [SerializeField] private float attachCooldown;

    private Animator animator;
    private Rigidbody2D rb2d;
    private float cooldownTimer = Mathf.Infinity;
    private Sensor groundCheck;
    private bool grounded = false;
    private bool combatIdle = false;
    private bool isDead = false;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 20;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck").GetComponent<Sensor>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Check if character just landed on the ground
        if (!grounded && groundCheck.State())
        {
            grounded = true;
            animator.SetBool("Grounded", grounded);
        }

        //Check if character just started falling
        if (grounded && !groundCheck.State())
        {
            grounded = false;
            animator.SetBool("Grounded", grounded);
        }


        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");


        // Swap direction of sprite depending on walk direction
        if (inputX < 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX > 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
        rb2d.velocity = new Vector2(inputX * speed, rb2d.velocity.y);

        //Set AirSpeed in animator
        animator.SetFloat("AirSpeed", rb2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e"))
        {
            if (!isDead)
                animator.SetTrigger("Death");
        }

        //Hurt
        else if (Input.GetKeyDown("q"))
            animator.SetTrigger("Hurt");

        //Attack
        else if (Input.GetMouseButtonDown(0))
        {
            if (cooldownTimer >= attachCooldown)
            {
                cooldownTimer = 0;
                Attack();
            }
                
        }

        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            combatIdle = !combatIdle;

        //Jump
        else if (Input.GetKeyDown("space")  && grounded)
        {
            
            
                animator.SetTrigger("Jump");
                grounded = false;
                animator.SetBool("Grounded", grounded);
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                groundCheck.Disable(0.2f);
                //groundCheck.Disable(2f);
           
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (combatIdle)
            animator.SetInteger("AnimState", 1);

        //Idle
        else
            animator.SetInteger("AnimState", 0);
    }

   
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit!" + enemy.name);
            if (enemy.GetComponent<GroundEnemyController>() != null)
            {
                enemy.GetComponent<GroundEnemyController>().TakeDamege(attackDamage);
            }
            if (enemy.GetComponent<ReactorControler>() != null)
            {
                enemy.GetComponent<ReactorControler>().TakeDamege(attackDamage);
            }
            if (enemy.GetComponent<BossP1Controler>() != null)
            {
                enemy.GetComponent<BossP1Controler>().TakeDamege(attackDamage);
            }
        }
    }
    public void TakeDamege(int damege)
    {
        currentHealth -= damege;
        healthBar.SetHealth(currentHealth);

        if(currentHealth > 0)
        {
            animator.SetTrigger("Hurt");
        }  
        else
        {
            if (!isDead)
                animator.SetTrigger("Death");
            
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Death"))
        {

            TakeDamege(currentHealth);

        }
    }

}


