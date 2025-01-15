using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
   public GameObject particle;
   public int initalPoolSize = 10;
   private Queue<GameObject> pool = new Queue<GameObject>();

   private void Awake()
   {
      for (int i = 0; i < initalPoolSize; i++)
      {
         CreateParticle();
      }
   }
   
   private void CreateParticle()
   {
      GameObject newParticle = Instantiate(particle);
      newParticle.SetActive(false);
      pool.Enqueue(newParticle);
   }
   
   public GameObject GetParticle()
   {
      if (pool.Count > 0)
      {
         var particle = pool.Dequeue();
         particle.SetActive(true);
         return particle;
      }
      else
      {
         CreateParticle();
         return GetParticle();
      }
   }
   
   public void ReturnParticle(GameObject particle)
   {
      particle.SetActive(false);
      pool.Enqueue(particle);
   }
}
