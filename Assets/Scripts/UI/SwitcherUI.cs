using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


namespace RPG.UI
{
    public class SwitcherUI : MonoBehaviour
    {
        [SerializeField] GameObject entryPoint;


        private void Start()
        {
            SwitchTo(entryPoint);

        }
        public void SwitchTo(GameObject toDisplay)
        {
            if (toDisplay.transform.parent != transform) return;

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(child.gameObject == toDisplay);
            }
        }

    }
}

