using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Gamemanager : MonoBehaviour
    {
        private static Gamemanager instance;
        public static Gamemanager Instance { get { return instance; } }

        [SerializeField] GameObject ps;
        [SerializeField] GameObject player;


        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {

        }

        public void Play()
        {
            SceneManager.LoadScene(1);
            SceneManager.sceneLoaded += LoadedNewScene;
        }

        private void LoadedNewScene(Scene arg0, LoadSceneMode arg1)
        {
            Debug.Log(arg0.name);
        }

        public void NextLevel()
        {
            StartCoroutine(Effects());
            ps.SetActive(true);
        }

        IEnumerator Effects()
        {
            yield return new WaitForSeconds(2f);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        }

    }
}