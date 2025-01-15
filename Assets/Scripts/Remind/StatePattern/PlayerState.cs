using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private Vector3 _prev;

    private void Start()
    {
        _prev = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.D))
        {
            _prev = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * 0.1f));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * (Time.deltaTime * 5));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * (Time.deltaTime * 5));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (Time.deltaTime * 5));
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.position = _prev;
        }
    }
}

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// 상태 패턴을 적용하지 않았을 때
// public class MonsterState : MonoBehaviour
// {
//     private Vector3 _prev;
//
//     private void Start()
//     {
//         _prev = transform.position;
//     }
//
//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) ||
//             Input.GetKeyDown(KeyCode.D))
//         {
//             _prev = transform.position;
//         }
//
//         if (Input.GetKeyDown(KeyCode.W))
//         {
//             transform.Translate(Vector3.forward * (Time.deltaTime * 0.1f));
//         }
//         else if (Input.GetKey(KeyCode.S))
//         {
//             transform.Translate(Vector3.down * (Time.deltaTime * 5));
//         }
//         else if (Input.GetKey(KeyCode.A))
//         {
//             transform.Translate(Vector3.left * (Time.deltaTime * 5));
//         }
//         else if (Input.GetKey(KeyCode.D))
//         {
//             transform.Translate(Vector3.right * (Time.deltaTime * 5));
//         }
//
//         if (Input.GetKeyDown(KeyCode.K))
//         {
//             transform.position = _prev;
//         }
//     }
// }

