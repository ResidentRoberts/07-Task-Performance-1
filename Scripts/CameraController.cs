using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform PLAYER1;
  private  void Update()
    {
        transform.position = new Vector3(PLAYER1.position.x, PLAYER1.position.y, transform.position.z);
    }
}
