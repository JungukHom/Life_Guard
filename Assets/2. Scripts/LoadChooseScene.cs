using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class LoadChooseScene : MonoBehaviour
{
    static int index = 0;
    public SteamVR_Action_Boolean menu;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }

	void Update()
    {
        if (menu.GetStateDown(SteamVR_Input_Sources.LeftHand))
		{
            SceneManager.LoadScene(index + 1);
		}
    }
}
