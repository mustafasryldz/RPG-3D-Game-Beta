using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using RPG.Shops;
using System;

namespace RPG.UI.Shops
{
    public class RowUI : MonoBehaviour
    {
        [SerializeField]
        Image iconField;
        [SerializeField]
        TextMeshProUGUI nameField;
        [SerializeField]
        TextMeshProUGUI availabilityField;
        [SerializeField]
        TextMeshProUGUI priceField;
        [SerializeField]
        TextMeshProUGUI quantityField;

        Shop currentShop = null;
        ShopItem item = null;


        public void Setup(Shop currentShop,ShopItem item)
        {
            this.currentShop = currentShop;
            this.item = item;
            iconField.sprite = item.GetIcon();
            nameField.text = item.GetName();
            availabilityField.text=$"{item.GetAVailability()}";
            priceField.text= $"{item.GetPrice()}";
            quantityField.text = $"{item.GetQuantityInTransaction()}";
        }

        public void Add()
        {
            currentShop.AddToTransaction(item.GetInventoryItem(), 1);
        }
        public void Remove()
        {
            currentShop.AddToTransaction(item.GetInventoryItem(), -1);
        }
    }

}
