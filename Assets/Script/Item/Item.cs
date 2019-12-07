using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType
{
    public enum Item_Type
    {
        SWORD,
        SHIELD
    }    
}

[CreateAssetMenu(fileName = "Item Templete", menuName = "Items")] 
public class Item : MonoBehaviour
{
    public Sprite image; //무기 이미지
    public ItemType.Item_Type type; //무기 타입
    public int powerUp; //무기 전투력
    public int hpUp; //무기 방어력
}
