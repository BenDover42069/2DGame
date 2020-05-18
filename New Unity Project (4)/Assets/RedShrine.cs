using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShrine : MonoBehaviour
{
    public TileMap ot;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);

            ot.GenerateRedShrine();

            TileMap.Red -= 1;
        }
        if (other.gameObject.tag == "Wall")
        {
            Debug.LogError("Killme");
            Destroy(this.gameObject);
            ot.GenerateRedShrine();
            TileMap.Red -= 1;
        }
    }
}
