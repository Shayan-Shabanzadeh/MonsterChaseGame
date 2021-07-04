using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    private Transform player;
    private string PLAYER_TAG = "Player";

    private Vector3 tempPos;

    [SerializeField] private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null)
            return;
        tempPos = transform.position;
        tempPos.x = player.position.x;
        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }else if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }
        transform.position = tempPos;
    }
}
