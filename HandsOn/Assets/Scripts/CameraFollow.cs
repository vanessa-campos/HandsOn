using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float followDelay = 4;
    PlayerController player;

    private Vector3 offset;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * followDelay);
    }
}
