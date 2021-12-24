using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)// Trigger ger�ekle�ti�i anda yap�lacaklar
    {
        Player.GetComponent<Karaktercontroller>().Onground = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)//Trigerdan ��k�� yap�ld���nda yap�lcaklar
    {
        Player.GetComponent<Karaktercontroller>().Onground = false;
    }
   
}
