using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public Item item;
    public ItemType.Item_Type type; //무기 타입
    public int powerUp; //무기 전투력
    public int hpUp; //무기 방어력
    
    void Start()
    {
        type = item.type;
        powerUp = item.powerUp;
        hpUp = item.hpUp;
    }
}
