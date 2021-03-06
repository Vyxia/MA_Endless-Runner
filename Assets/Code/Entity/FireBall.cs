﻿using UnityEngine;
using System.Collections;

public class FireBall : Entity
{

    private float startMoveTimer = 1f;

    public override void Start()
    {

        base.Start();
    }

    public override void Update()
    {

        base.Update();

        startMoveTimer -= 1f * Time.deltaTime;
        if (startMoveTimer <= 0f)
        {
            moveEntity();
        }
    }

    public override void moveEntity()
    {

        base.moveEntity();

        this.transform.position += new Vector3(0, -0.09f);
    }
}
