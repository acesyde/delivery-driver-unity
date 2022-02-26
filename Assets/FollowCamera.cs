using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0,0,-10);
    }
}
