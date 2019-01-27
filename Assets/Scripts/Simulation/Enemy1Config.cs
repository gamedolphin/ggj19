using UnityEngine;
using UniRx;
using System;

public class Enemy1Config : EnemyConfig {

    private static int [] dirs = new int[] { 1, -1 };
    private float speed = 10;

    private static Vector2 GetRandomDirection() {
        bool horizontal = UnityEngine.Random.Range(0,10) > 5;
        int x = dirs[UnityEngine.Random.Range(0,2)];
        if(horizontal) {
            return new Vector2(x,0);
        }
        else {
            return new Vector2(0,x);
        }
    }

    private Vector2 direction = Vector3.zero;

    private void Start() {
        direction = GetRandomDirection();
        Observable.Interval(TimeSpan.FromSeconds(4))
            .TakeUntilDestroy(this)
            .Subscribe(_ => {
                    direction = GetRandomDirection();
                });
    }

    public void FixedUpdate() {
        var target = transform.position + speed * (new Vector3(direction.x, 0, direction.y)).normalized;
        if(target.x > 150 ) direction.x = -1;
        if(target.x < 0) direction.x = 1;
        if(target.z > 150 ) direction.y = -1;
        if(target.z < 0) direction.y = 1;
        transform.position = Vector3.Lerp(transform.position, target, Time.fixedDeltaTime);
    }
}
