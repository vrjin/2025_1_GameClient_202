using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Newtonsoft.Json;
using UnityEditor.Build;
using Unity.VisualScripting;

public class ItemDataLoader : MonoBehaviour
{
    [SerializeField]
    private string jsonFileName = "items";

    private List<ItemData> itemList;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private string EncodeKorean(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        byte[] bytes = Encoding.Default.GetBytes(text);
        return Encoding.UTF8.GetString(bytes);
    }








    void LoadItemData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);

        if (jsonFile != null)
        {
            //���� �ؽ�Ʈ���� UTF-8 �� ��ȯ ó��
            byte[] bytes = Encoding.Default.GetBytes(jsonFile.text);
            string correntText = Encoding.UTF8.GetString(bytes);

            //��ȯ�� �ؽ�Ʈ ���
            itemList = JsonConvert.DeserializeObject<List<ItemData>>(correntText);

            Debug.Log($"�ε�� ������ �� : {itemList.Count}");

           // foreach (var item in itemList)
            {
               // Debug.Log($"������ : {EncodeKorean(item.itemName)}, ���� : {EncodeKorean(item.description)}");
            }
            //else
            {
                Debug.LogError($"JSON ������ ã���� �����ϴ�. : {jsonFileName}");
            }

        }
    }
    
}
