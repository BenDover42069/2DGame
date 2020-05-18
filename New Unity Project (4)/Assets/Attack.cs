using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public int attack = 0;
    public Text attackText;

    void Update()
    {
        attackText.text = " " + attack;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack++;
        }
    }
}
