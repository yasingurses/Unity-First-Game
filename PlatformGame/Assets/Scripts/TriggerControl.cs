using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)// Trigger gerçekleþtiði anda yapýlacaklar
    {
        Player.GetComponent<Karaktercontroller>().Onground = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)//Trigerdan çýkýþ yapýldýðýnda yapýlcaklar
    {
        Player.GetComponent<Karaktercontroller>().Onground = false;
    }
   
}
