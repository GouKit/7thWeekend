using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
 
[SerializeField]
public class ItemSlot
{
    public ItemType.Item_Type type; //무기 타입
    public int powerUp; //무기 전투력
    public int hpUp; //무기 방어력
    public ItemSlot(ItemType.Item_Type Type, int power, int hp)
    {
        this.type = Type;
        this.powerUp = power;
        this.hpUp = hp;
    }
}

public class Inventory : MonoBehaviour
{
    public GameObject bag;
    public List<GameObject> items;
    private List<ItemSlot> itemSlots = new List<ItemSlot>();
    
    void Start()
    {
        SetSlot(0);
    }

    public void Show()
    {
        if(bag.transform.childCount >= items.Count)
            return;

        int index = items.Count - (items.Count - itemSlots.Count);

        SetSlot(index);

        for(int i = index; i < items.Count; i++)
        {
            GameObject obj = new GameObject("slot");
            obj.AddComponent<Image>();

            ItemBase ib = items[i].GetComponent<ItemBase>();
            obj.GetComponent<Image>().sprite = ib.item.image;

            obj.transform.SetParent(bag.transform);
        }
    }

    void SetSlot(int index)
    {
        for(int i = index; i < items.Count; ++i)
        {
            ItemBase ib = items[i].GetComponent<ItemBase>();
            itemSlots.Add(new ItemSlot(ib.type, ib.powerUp, ib.hpUp));
        }
    }

    public void AddItem(GameObject obj)
    {
        items.Add(obj);
    }
}
