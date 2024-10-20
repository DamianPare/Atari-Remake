using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int blockLevel;
    public int value;
    

    public void OnDestroy()
    {
        GameManager.instance.AddMoney(value);
    }
}
