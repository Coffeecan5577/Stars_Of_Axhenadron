using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] private float levelLoadDelay = 1.5f;
    [Tooltip("FX prefab on player")][SerializeField] private GameObject _deathExplosion;

    void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player dying.");
        SendMessage("OnPlayerDeath");
        _deathExplosion.SetActive(true);
        Invoke("ReloadCurrentLevel", levelLoadDelay);
    }

    private void ReloadCurrentLevel() // string referenced
    {
        var currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}
