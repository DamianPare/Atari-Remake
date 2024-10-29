using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int blockLevel;
    public int value;
    public GameObject damagedBlock;
    

    public void OnDisable()
    {
        GameManager.instance.AddMoney(value);
    }

    public void DamageBlock()
    {
        blockLevel--;
        damagedBlock.SetActive(true);
    }
}
