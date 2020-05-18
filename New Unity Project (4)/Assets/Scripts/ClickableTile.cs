using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour
{
    
   public int x = TileMap.x;
   public int y = TileMap.y;
    public TileMap map;
    public GameObject SelectedArrow;
    public int Selected;
    public GameObject SelectedEnemyWall;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {



            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (Physics2D.Raycast(ray.origin, ray.direction))
            {
                
                    if (hit.collider.tag == "Floor")
                    {
                    if (Selected == 0 || Selected == 1)
                    {
                        map.GeneratePathTo(x, y);

                        Instantiate(SelectedArrow, new Vector3(x, y, 0), Quaternion.identity);

                        Selected += 1;
                    }
                    if (Selected > 1)
                    {
                        var clicked = GameObject.FindGameObjectsWithTag("ClickedTile");
                        foreach (GameObject SelectedArrow in clicked)
                        {
                            Destroy(SelectedArrow);
                        }

                        Selected -= 1;

                        map.GeneratePathTo(x, y);

                        Instantiate(SelectedArrow, new Vector3(x, y, 0), Quaternion.identity);

                        Selected += 1;
                    }
                    }
                
                    
            }
        }
    }
    /*public void OnMouseUp()
    {
        

        if (Selected == 0 || Selected == 1 )
        
        {
            
        
            Debug.Log("Click!");

            map.GeneratePathTo(x, y);

            Instantiate(SelectedArrow, new Vector3(x, y, 0), Quaternion.identity);

            Selected += 1;

           
        }

        /* if (Selected == 0 || Selected == 1 || gameObject.tag == "Wall")
        {
            map.GeneratePathTo(x, y);

            Instantiate(SelectedEnemyWall, new Vector3(x, y, 0), Quaternion.identity);

            Selected += 1;
        }
        
        if (Selected > 1)
        {
            var clicked = GameObject.FindGameObjectsWithTag("ClickedTile");
            foreach ( GameObject SelectedArrow in clicked)
            {
                Destroy(SelectedArrow);
            }

            Selected -= 1;

            map.GeneratePathTo(x, y);

            Instantiate(SelectedArrow, new Vector3(x,y, 0), Quaternion.identity);

            Selected += 1;

        }



    }*/

}