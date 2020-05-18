using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTile : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (Physics2D.Raycast(ray.origin, ray.direction))
            {
                if (hit.collider.tag == "EnemyHead")
                {

                }
            }
        }
    }
}
