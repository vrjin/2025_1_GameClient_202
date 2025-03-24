using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;



[CreateAssetMenu(fileName = " ItemDatabase" ,  menuName = "Inventory/Database")]



public class ItemDatabaseSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();

    private Dictionary<int, ItemSO> itemsByld;
    private Dictionary<string, ItemSO> itemsByName;

    public void Initialze()
    {
        itemsByld = new Dictionary<int, ItemSO>();
        itemsByName = new Dictionary<string, ItemSO>();

        foreach (var item in items)
        {
            itemsByld[item.id] = item;
            itemsByName[item, itemName] = item;
        }
    }
}


