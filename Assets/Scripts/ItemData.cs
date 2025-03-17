using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ItemData 
{
    public int id;
    public string itemName;
    public string doscription;
    public string nameEng;
    public string itemTypesString;
    [NonSerialized]
    public itemType itemType;
    public int price;
    public int power;
    public int level;
    public bool isStackable;
    public string iconPath;


    //문자열을 일거함으로 변화하는 메서드
    public void InitalizeEnums()
    {
        if (Enum.TryParse(itemTypesString, out itemType persedType))
        {
            itemType = persedType;
        }
        else
        {
            Debug.LogError($"아이템'{itemName}'에 유호하지 아이템 타입 : {itemTypesString}");
            //기본값으로 설정
            itemType = itemType.Consumable;

        }
    }


     


}
