using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public Follow Follow;
        public float Cooldown;
        private Coroutine _aggroCoroutine;
        private bool _hasAggroTarget;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            SwitchFollowOff();
        }

        private void TriggerExit(Collider2D obj)
        {
            if (!_hasAggroTarget)
            {
                _hasAggroTarget = true;
                _aggroCoroutine = StartCoroutine(SwitchFollowOffAfterCooldown());
            }
        }

        private IEnumerator SwitchFollowOffAfterCooldown()
        {
            yield return new WaitForSeconds(Cooldown);
            SwitchFollowOff();
            Debug.Log("EnenemyAnt not MoveToPlayer");
        }

        private void TriggerEnter(Collider2D obj)
        {
            if (_hasAggroTarget)
            {
                _hasAggroTarget = false;
                StopAggroCoroutine();
                SwitchFollowOn();
            }
        }

        private void StopAggroCoroutine()
        {
            if (_aggroCoroutine != null)
            {
                StopCoroutine(_aggroCoroutine);
                _aggroCoroutine = null;
            }
        }

        private void SwitchFollowOn() => 
            Follow.enabled = true;

        private void SwitchFollowOff() =>
            Follow.enabled = false;
    }
}