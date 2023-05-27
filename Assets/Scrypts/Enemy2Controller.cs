using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2Controller : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 2f;
    private Rigidbody2D rigidbody2D;
    public GameObject explosionGo;
    private SpawnerControler spawner;



    //Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        //spawner = GameObject.Find("Spawner").GetComponent<SpawnerControler>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {

            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            rigidbody2D.rotation = angle;

            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
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
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            DoDamageToEnemy();

        }
    }

    void DoDamageToEnemy()
    {

        
        PlayExplosion();
        Destroy(gameObject);
       

    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(explosionGo);

        explosion.transform.position = transform.position;
    }
    /*
    void FixedUpdate()
    {
        void OnTriggerEnter2D(Collider collider)
        {
            Debug.Log("Trigger.");
            if (collider.gameObject.tag == "Enemy")
            {
                Destroy(collider.gameObject);
                Destroy(gameObject);
            }
        }
    }
    */
}
