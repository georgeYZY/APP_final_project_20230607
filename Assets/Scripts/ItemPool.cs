using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    public GameObject itemPrefab;  // 物品預置體
    public int poolSize = 10;  // 池子大小

    private List<ItemScript> itemPool;  // 物品池

    private void Awake()
    {
        itemPool = new List<ItemScript>();

        // 預先建立一定數量的物品
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);

            ItemScript item = obj.GetComponent<ItemScript>();
            if (item == null)
            {
                item = obj.AddComponent<ItemScript>();
            }

            itemPool.Add(item);
        }
    }

    public ItemScript GetItem()
    {
        // 從池子中取出一個可用的物品
        foreach (ItemScript item in itemPool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                item.gameObject.SetActive(true);
                return item;
            }
        }

        // 如果沒有可用的物品，就創建一個新的並添加到池子中
        GameObject obj = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        ItemScript newItem = obj.GetComponent<ItemScript>();
        itemPool.Add(newItem);

        return newItem;
    }
}
