using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageLevels : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
	{
        Invoke("LoadLevel", 2.0f);
    }

    
	
	// Update is called once per frame
	void Update ()
	{
	    
	}

    private void LoadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;
        int levelCount = SceneManager.sceneCount;

        if (currentLevel < levelCount)
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            // Reload the splash screen.
            SceneManager.LoadScene(0);
        }
    }

}
