using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    private void Start()
    {
        PhotonNetwork.Instantiate("Character", Vector3.zero, Quaternion.identity);
    }
}
