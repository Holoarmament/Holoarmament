using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,Ienemy
{
   public float health = 50f;

   public void Damage(float shot)
   {
        health -= shot;
        if(health <= 0f)
        {
            Destroy(gameObject);
        }
   }
}
