using UnityEngine;
using System.Collections;

namespace Assets.CodeBase.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}