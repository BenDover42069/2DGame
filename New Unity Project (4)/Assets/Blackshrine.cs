using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackshrine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public TileMap ot;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);

            ot.GenerateBlackShrine();

            TileMap.Black -= 1;
            
        }
        if (other.gameObject.tag == "Wall")
        {
            Debug.LogError("Killme");
            Destroy(this.gameObject);
            ot.GenerateBlackShrine();
            TileMap.Black -= 1;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
