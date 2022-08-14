using System;
using System.Collections;
using System.Collections.Generic;
using GameDevTV.Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {

        private const string currentSaveKey = "currentSaveName";
        [SerializeField] float fadeInTime = 0.2f;
        [SerializeField] float fadeOutTime = 0.2f;
        [SerializeField] int firstLevelBuildIndex = 1;
        [SerializeField] int menuSceneBuildIndex = 0;
        public void ContinueGame() 
        {
            //basti = true;
            if (!PlayerPrefs.HasKey(currentSaveKey)) return;
            //basti2 = true;
            if (!GetComponent<SavingSystem>().SaveFileExist(GetCurrentSave())) return;
            //basti3 = true;
            StartCoroutine(LoadLastScene());
        }

        public void NewGame(string saveFile)
        {
            if (String.IsNullOrEmpty(saveFile)) return;
            SetCurrentSave(saveFile);
            StartCoroutine(LoadFirstScene());
        }
        public void LoadGame(string saveFile)
        {
            SetCurrentSave(saveFile);
            ContinueGame();
        }

        private void SetCurrentSave(string saveFile)
        {
            PlayerPrefs.SetString(currentSaveKey, saveFile);
        }

        private string GetCurrentSave()
        {
            return PlayerPrefs.GetString(currentSaveKey);
        }

        public void LoadMenu()
        {
            StartCoroutine(LoadMenuScene());
        }
        private IEnumerator LoadLastScene() {
            Fader fader = FindObjectOfType<Fader>();

            yield return fader.FadeOut(fadeOutTime);
            yield return GetComponent<SavingSystem>().LoadLastScene(GetCurrentSave());
            yield return fader.FadeIn(fadeInTime);
        }
        private IEnumerator LoadFirstScene()
        {
            Fader fader = FindObjectOfType<Fader>();

            yield return fader.FadeOut(fadeOutTime);
            yield return SceneManager.LoadSceneAsync(firstLevelBuildIndex);
            yield return fader.FadeIn(fadeInTime);
        }
        private IEnumerator LoadMenuScene()
        {
            Fader fader = FindObjectOfType<Fader>();

            yield return fader.FadeOut(fadeOutTime);
            yield return SceneManager.LoadSceneAsync(menuSceneBuildIndex);
            yield return fader.FadeIn(fadeInTime);
        }
        private void Update() {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Delete();
            }
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(GetCurrentSave());
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(GetCurrentSave());
        }

        public void Delete()
        {
            GetComponent<SavingSystem>().Delete(GetCurrentSave());
        }
        public IEnumerable<string> ListSaves()
        {
            return GetComponent<SavingSystem>().ListSaves();
        }
    }
}