using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenShrine : MonoBehaviour
{
    public TileMap ot;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);

            ot.GenerateGreenShrine();
            TileMap.Green -= 1;
        }
        if (other.gameObject.tag == "Wall")
        {
            Debug.LogError("Killme");
            Destroy(this.gameObject);
            ot.GenerateGreenShrine();
            TileMap.Green -= 1;
        }
    }
}
