using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ShieldPosition : MonoBehaviourPunCallbacks
{
    [Tooltip("The maximux height that the shield will go to from it's start point.")]
    [SerializeField] float floatingHeight = 0.3f;

    [Tooltip("The speed in which the shield will go up and down")]
    [SerializeField] float floatingSpeed;

    [Tooltip("The speed in which the shield will rotate")]
    [SerializeField] float rotatingSpeed;

    private Vector3 startPoint;

    void Start()
    { 
        startPoint = transform.position;
    }

    void Update()
    {
        // Calculate the new height change - from (-floatingHeight) to (+floatingHeight):
        float deltaHeight = floatingHeight * Mathf.Sin(Time.time * floatingSpeed);

        transform.position = new Vector3(startPoint.x, startPoint.y + deltaHeight, startPoint.z);

        transform.Rotate(new Vector3(0, rotatingSpeed, 0));
    }

    public void removeFromWorld()
    {
        if (photonView.IsMine)
            PhotonNetwork.Destroy(gameObject);
    }
}