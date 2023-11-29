using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mask_Aim : MonoBehaviour
{
    public GameObject Player;
    public RectMask2D Mask;

    private void Update()
    {
        Mask.padding = new Vector4(0, 0, 270 - Player.GetComponent<movement>().launchForce / 20 * 270, 0);
    }
}
