using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy5Controller : MonoBehaviour
{
    public GameObject kredytDrop;
    private Transform player;
    public float moveSpeed = 2f;
    public float stopDistance;
    public float retreatDistance;
    public GameObject projectile4;
    private Rigidbody2D rigidbody2D;
    public float statTime;
    private float timeBtwShots;

    public Transform firePoint;
    public float projectileForce = 10f;
    public GameObject explosionGo;
    public int maxHealth = 1500;
    public int currentHealth;
    public HealthBar healthBar;

    //Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        //firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
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




            if (timeBtwShots <= 0)
            {

                GameObject pro1 = Instantiate(projectile4, firePoint.position, firePoint.rotation);

                Rigidbody2D rb1 = pro1.GetComponent<Rigidbody2D>();

                rb1.AddForce(-firePoint.up * projectileForce, ForceMode2D.Impulse);

                
                timeBtwShots = statTime;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }


        }
        else
        {
            SceneManager.LoadScene("GameOver");
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

        if (collider.CompareTag("Enemy"))
        {
            
            MoveAway();
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

    void MoveAway()
    {

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