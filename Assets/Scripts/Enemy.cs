using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyDeathExplosion;
    private float _explosionResetDelay = 0.2f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        print("Particles collided with enemy: " + gameObject.name);
        DestroyEnemy();
       // Invoke("ResetExplosion", _explosionResetDelay);
    }

    private void DestroyEnemy()
    {
        //_enemyDeathExplosion.SetActive(true);
        Destroy(gameObject);
       
    }

    //private void ResetExplosion()
    //{
    //    _enemyDeathExplosion.SetActive(false);
    //}
}
