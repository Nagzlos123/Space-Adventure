using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerOfPro : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
         void OnTriggerEnter2D(Collider2D collider)
        {

            if(collider.CompareTag("EnemyProjectile"))
            {
                Destroy(collider.gameObject);

            }


        }
    }
}
