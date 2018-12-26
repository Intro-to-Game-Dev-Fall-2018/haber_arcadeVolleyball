using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boosts : MonoBehaviour
{
    [SerializeField] private Boost boost;
    
    private void Start()
    {
        createNewBoost();
    }

    private void createNewBoost()
    {
        Boost b =Instantiate(boost);
        b.ballHit.AddListener(()=>
        {       
            Destroy(b.gameObject);
            createNewBoost();
        });
    }
    
}



