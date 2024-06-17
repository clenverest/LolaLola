using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject ItemPrefab;
    public int Amount;
    public bool IsEmpty = true;
    public TMP_Text ItemAmountText;

    public void SetItem(GameObject item, Transform parent)
    {
        Instantiate(item, parent);
    }

    public void DestroyItem(GameObject item)
    {
        foreach(Transform child in transform)
        {
            if(child.gameObject.GetComponent<TMP_Text>() == null)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
