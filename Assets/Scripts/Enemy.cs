using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	    AddNonTriggerBoxCollider();
	}
	

    void OnParticleCollision(GameObject other)
    {
        DestroyEnemy();
       // Invoke("ResetExplosion", _explosionResetDelay);
    }

    private void DestroyEnemy()
    {
        //_enemyDeathExplosion.SetActive(true);
        Destroy(gameObject);
       
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    //private void ResetExplosion()
    //{
    //    _enemyDeathExplosion.SetActive(false);
    //}
}
