using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 싱글톤 패턴 복기
public class SingletonPattern : MonoBehaviour
{
   private static SingletonPattern instance;
   
   //인스턴스가 없으면 null을 반환하는 프로퍼티
   public static SingletonPattern Instance
   {
      get
      {
         return instance;
      }
   }

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else
      {
         //이미 인스턴스가 존재하는 경우 새로운 오브젝트 제거
         if (instance != this && instance != this)
         {
            Destroy(gameObject);
         }
      }
   }
}