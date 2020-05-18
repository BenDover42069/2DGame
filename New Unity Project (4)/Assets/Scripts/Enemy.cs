using System.Collections;
using System.Linq;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int x = TileMap.x;
    public int y = TileMap.y;
    public TileMap map;
  
    public ClickableTile Clickable;
    // Start is called before the first frame update
    public GameObject SelectedArrow;



    // Update is called once per frame
   
    
   /* public void OnMouseDown()
    {
        
         map.GeneratePathTo(x, y);

        Instantiate(SelectedArrow, new Vector3(x, y, 0), Quaternion.identity);

        Selected.Selected += 1;
    }
    */
    public void fuckme ()
    {

    }
   void OnMouseDown()
    {
        map.GeneratePathTo(x, y);
        Instantiate(SelectedArrow, transform.position, transform.rotation);
        Clickable.Selected += 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            Destroy(this.gameObject);
            Debug.LogError("SPAWNED ON WALL");
        }

        if (other.gameObject.tag == "Wall")
        {

            Destroy(this.gameObject);
            Debug.LogError("SPAWNED ON WALL");
        }

        
    }
    
   
}

