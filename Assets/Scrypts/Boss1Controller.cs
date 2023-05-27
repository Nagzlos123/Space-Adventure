using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1Controller : MonoBehaviour
{
    
    private Transform player;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stopDistance;
    [SerializeField] private float retreatDistance;
    public GameObject projectile3;
    public GameObject projectile4;
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float statTime;
    private float timeBtwShots;

    [SerializeField] private Transform[] moveSpots;
    [SerializeField] private float startWaitTimer;
    [SerializeField] private float waitTimer;
    private int randomSpot;

    public Transform bossFirePoint1;
    public Transform bossFirePoint2;
    public Transform bossFirePoint11;
    public Transform bossFirePoint22;
    public Transform bossFirePoint;
    public float projectileForce = 10f;
    public GameObject explosionGo;
    public int maxHealth = 5000;
    public int currentHealth;
    public HealthBar healthBar;
    

    //Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        waitTimer = startWaitTimer;
        timeBtwShots = statTime;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = moveSpots[randomSpot].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rigidbody2D.rotation = angle;
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position,moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTimer <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTimer = startWaitTimer;
            }
            else
            {
                waitTimer -= Time.deltaTime;
                AttackPlayer();
                
                //Shootingprojectile4();
            }

        }
        if (player != null)
        {
            /*
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
            */



            Shooting();


        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }


    }

    private void AttackPlayer()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rigidbody2D.rotation = angle;
        

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

    void Shootingprojectile3()
    {
        GameObject pro1 = Instantiate(projectile3, bossFirePoint1.position, bossFirePoint1.rotation);
        GameObject pro2 = Instantiate(projectile3, bossFirePoint2.position, bossFirePoint2.rotation);

        Rigidbody2D rb1 = pro1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = pro2.GetComponent<Rigidbody2D>();

        rb1.AddForce(-bossFirePoint1.up * projectileForce, ForceMode2D.Impulse);
        rb2.AddForce(-bossFirePoint2.up * projectileForce, ForceMode2D.Impulse);
    }

    void Shootingprojectile4()
    {
        GameObject pro1 = Instantiate(projectile4, bossFirePoint11.position, bossFirePoint11.rotation);
        GameObject pro2 = Instantiate(projectile4, bossFirePoint22.position, bossFirePoint22.rotation);

        Rigidbody2D rb1 = pro1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = pro2.GetComponent<Rigidbody2D>();

        rb1.AddForce(-bossFirePoint11.up * projectileForce, ForceMode2D.Impulse);
        rb2.AddForce(-bossFirePoint22.up * projectileForce, ForceMode2D.Impulse);
    }

    void Shooting()
    {
        if (timeBtwShots <= 0)
        {

            Shootingprojectile3();
            //Shootingprojectile4();



            timeBtwShots = statTime;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;

        }
    }

}