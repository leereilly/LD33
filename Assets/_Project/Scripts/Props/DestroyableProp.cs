﻿using System.Collections;
using Assets._Project.Scripts.Characters;
using UnityEngine;

namespace Assets._Project.Scripts.Props
{
    [RequireComponent(typeof(Health))]
    public class DestroyableProp : MonoBehaviour
    {
        public GameObject OnDestroyEffectPrefab;
        public float DestroyDelay = 0f;

        public virtual void Start()
        {
            GetComponent<Health>().OnDeath += OnDeath;
        }

        private void OnDeath(GameObject obj)
        {
            CheckDeath();
        }

        private void CheckDeath()
        {
            if (GetComponent<Health>().Dead)
            {
                StartCoroutine(DelayedDestroy());
            }
        }

        protected virtual IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(DestroyDelay);
            Destroy();
        }

        protected void Destroy()
        {
            if (OnDestroyEffectPrefab != null)
            {
                Instantiate(OnDestroyEffectPrefab, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}