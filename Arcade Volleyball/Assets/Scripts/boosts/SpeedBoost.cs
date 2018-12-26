using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Boost
{
    protected override void onBallHit(BallController ballController)
    {
        print(ballController.lastHit());    
    }
}
