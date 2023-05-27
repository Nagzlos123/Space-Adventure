using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy4Controler : MonoBehaviour
{
    public GameObject kredytDrop;
    private Transform player;
    public float moveSpeed = 2f;
    public float stopDistance;
    public float retreatDistance;
    public GameObject projectile3;
    private Rigidbody2D rigidbody2D;
    public float statTime;
    private float timeBtwShots;

    public Transform firePoint11;
    public Transform firePoint22;
    public float projectileForce = 10f;
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
        //firePoint11 = GameObject.Find("FirePoint11").GetComponent<Transform>();
        //firePoint22 = GameObject.Find("FirePoint22").GetComponent<Transform>();
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

                    GameObject pro1 = Instantiate(projectile3, firePoint11.position, firePoint11.rotation);
                    GameObject pro2 = Instantiate(projectile3, firePoint22.position, firePoint22.rotation);

                    Rigidbody2D rb1 = pro1.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = pro2.GetComponent<Rigidbody2D>();

                    rb1.AddForce(firePoint11.up * projectileForce, ForceMode2D.Impulse);
                    rb2.AddForce(firePoint22.up * projectileForce, ForceMode2D.Impulse);

                    //Instantiate(projectile2, transform.position, Quaternion.identity);
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