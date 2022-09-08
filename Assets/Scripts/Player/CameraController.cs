using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - targetPlayer.position;
    }

    void LateUpdate()
    {
        transform.position = targetPlayer.position + offset;
    }
}
