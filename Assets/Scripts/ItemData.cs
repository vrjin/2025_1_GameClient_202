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


    //���ڿ��� �ϰ������� ��ȭ�ϴ� �޼���
    public void InitalizeEnums()
    {
        if (Enum.TryParse(itemTypesString, out itemType persedType))
        {
            itemType = persedType;
        }
        else
        {
            Debug.LogError($"������'{itemName}'�� ��ȣ���� ������ Ÿ�� : {itemTypesString}");
            //�⺻������ ����
            itemType = itemType.Consumable;

        }
    }


     


}
