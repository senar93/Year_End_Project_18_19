﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWaitingState : PlatformStateBase
{
    protected override void Tick()
    {
        if (myContext.myPlatform.GetCanFade())
        {
            myContext.myPlatform.myRayCon.CheckRaycastsBools(myContext.myPlatform.myRayCon.faderMask);
        }
    }

    protected override void Exit()
    {
        myContext.myPlatform.myRayCon.Collisions.ResetCollisionInfo();
    }
}