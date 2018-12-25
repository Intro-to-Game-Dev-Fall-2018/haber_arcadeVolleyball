using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boosts : Speed
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

public class Speed : Boost
{
    protected override void onBallHit(BallController ballController)
    {
        print(ballController.lastHit());
        
    }
}

public abstract class Boost : MonoBehaviour
{
    public UnityEvent ballHit;
    
    private void Start()
    {
        transform.position = new Vector3(Random.Range(-2,2),Random.Range(-2,2),0);
        ballHit = new UnityEvent();
        gameObject.AddComponent<CircleCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        BallController ballController;
        if ((ballController = other.gameObject.GetComponent<BallController>()) == null) return;
        
        onBallHit(ballController);
        ballHit.Invoke();

    }

    protected abstract void onBallHit(BallController ballController);
}