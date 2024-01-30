using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public static event System.Action OnFruitDestroyed; // Define the event
    public GameObject fruitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
            ScoreCounter.score++;
            
            // Trigger the event
            if (OnFruitDestroyed != null)
            {
                OnFruitDestroyed();
            }
        }
    }
}