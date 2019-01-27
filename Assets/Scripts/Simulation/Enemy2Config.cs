using UnityEngine;
using UniRx;
using System;
using Server;
using Zenject;
using System.Linq;

public class Enemy2Config : EnemyConfig {

    private static int [] dirs = new int[] { 1, -1 };
    private float speed = 5;

    private Vector3 initialPosition;
    private float _angle;
    private float RotateSpeed = 1f;
    private float Radius = 10f;

    [Inject] private ServerSimulation serverSimulation;

    private void Start() {
        initialPosition = transform.position;
    }

    public void FixedUpdate() {

        var closePlayer = serverSimulation.playerList.Find(p => {
                return Vector3.Distance(transform.position, p.transform.position) < 4;
            });

        if(closePlayer != null && Vector3.Distance(transform.position, initialPosition) < 20)  {
            transform.position = Vector3.Lerp(transform.position, closePlayer.transform.position, speed*Time.fixedDeltaTime);
        }
        else {
             _angle += RotateSpeed * Time.deltaTime;
         var offset = new Vector3(Mathf.Sin(_angle),0, Mathf.Cos(_angle)) * Radius;
         var pos = initialPosition + offset;
         transform.position = Vector3.Lerp(transform.position, pos, Time.fixedDeltaTime);
        }
    }
}
