using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controler : MonoBehaviour
{
    public GameObject kredytDrop;
    private Transform player;
    public float moveSpeed = 5f;
    public float stopDistance;
    public float retreatDistance;
    public GameObject projectile2;
    private Rigidbody2D rigidbody2D;
    public float statTime;
    private float timeBtwShots;

    //public Transform firePoint1;
    //public Transform firePoint2;
    //public float projectileForce = 20f;
    public GameObject explosionGo;
    public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;

    //Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rigidbody2D.rotation = angle;

            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
            }
        }


        if (timeBtwShots <= 0)
        {
           

            //Instantiate(projectile2, transform.position, Quaternion.identity);
            timeBtwShots = statTime;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

      
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider.gameObject);
    }
    void ProcessCollision(GameObject collider)
    {

        if (collider.CompareTag("Projectile"))
        {
            Destroy(collider.gameObject);
            DoDamageToEnemy();
        }
    }

    void DoDamageToEnemy()
    {
        TakeDamege(5);


        if (currentHealth == 0)
        {
            PlayExplosion();
            Destroy(gameObject);
            Instantiate(kredytDrop, transform.position, Quaternion.identity);
        }

    }

    void TakeDamege(int damege)
    {
        currentHealth -= damege;
        healthBar.SetHealth(currentHealth);
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(explosionGo);

        explosion.transform.position = transform.position;
    }

}

