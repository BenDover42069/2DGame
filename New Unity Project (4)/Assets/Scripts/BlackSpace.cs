using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSpace : MonoBehaviour
{
    /*public GameObject Undiscovered;

    void Start()
    {
        int x = TileMap.x;
        int y = TileMap.y;
        for (x = 0; x <= 23; x++)
        {
            for (y = 0; y < 18; y++)
            {
                Instantiate(Undiscovered, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }
    */
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public int MaxShield = 50;
    public int currentShield;
    public ShieldBar shieldbar;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            Debug.Log("PLAYER!");
            Destroy(this.gameObject);
        }

    }
}

   


   
    




/* void LateUpdate(Collider2D col)
 {
     if (col.GetComponent<Unit>())
     {
         gameObject.GetComponent<SpriteRenderer>().enabled = false;

     }

     else
     {
         gameObject.GetComponent<SpriteRenderer>().enabled = true;
     }
 }
}*/









