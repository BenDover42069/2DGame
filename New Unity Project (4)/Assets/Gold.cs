using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int gold = 0;
    public Text goldText;

    void Update()
    {
        goldText.text = " " + gold;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gold++;
        }
    }
}
