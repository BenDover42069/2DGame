using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueShrine : MonoBehaviour
{

    public TileMap ot;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            Destroy(this.gameObject);
            ot.GenerateBlueShrine();
            TileMap.Blue =- 1;
        }
        if (other.gameObject.tag == "Wall")
        {

            Destroy(this.gameObject);
            ot.GenerateBlueShrine();
            TileMap.Blue =- 1;
        }
    }
}
