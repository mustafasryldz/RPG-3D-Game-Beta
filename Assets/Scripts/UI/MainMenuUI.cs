using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.SceneManagement;
using GameDevTV.Utils;
using System;
using TMPro;


namespace RPG.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        LazyValue<SavingWrapper> savingWrapper;

        //public SavingWrapper save;
        [SerializeField] TMPro.TMP_InputField newGameNameField;
        //SavingWrapper saveWrap;

        private void Awake()
        {
            savingWrapper = new LazyValue<SavingWrapper>(GetSavingWrapper);
        }
        private void Start()
        {
            //saveWrap = FindObjectOfType<SavingWrapper>();
        }
        private SavingWrapper GetSavingWrapper()
        {
            return FindObjectOfType<SavingWrapper>();
        }

        public void ContinueGame()
        {
            //save = savingWrapper.value;
            savingWrapper.value.ContinueGame();

            //saveWrap.ContinueGame();
        }
        public void NewGame()
        {
            savingWrapper.value.NewGame(newGameNameField.text);
            //saveWrap.ContinueGame();
        }
        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}

