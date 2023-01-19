using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _safeSpawnDistance;
    public bool IsOnSafeDistanceFromX(float x) =>  x - transform.position.x > _safeSpawnDistance;
}
