using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IFindPathProxy
{
   UniTask<Vector3[]> CalculatePath(Vector3 start, Vector3 end);
   bool IsCalculated { get; } //계산이 진행되고 있는지
   float Progress { get; } //계산률
}