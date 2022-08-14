using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GameDevTV.Inventories;
using RPG.Shops;


namespace RPG.UI.Shops
{
    public class FilterButtonUI : MonoBehaviour
    {
        [SerializeField] ItemCategory category = ItemCategory.None;

        Button button;
        Shop currentShop;
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SelectFilter);
        }
        private void Start()
        {
            
        }
        public void SetShop(Shop currentShop)
        {
            this.currentShop = currentShop;
        }
        public void RefreshUI()
        {
            button.interactable = currentShop.GetFilter() != category;
        }
        private void SelectFilter()
        {
            currentShop.SelectFilter(category);
        }

    }

}
