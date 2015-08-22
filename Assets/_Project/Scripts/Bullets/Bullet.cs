﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets._Project.Scripts.Characters;
using UnityEngine;

namespace Assets._Project.Scripts.Bullets
{
    public class Bullet : MonoBehaviour
    {
        public int Damage;
        public GameObject OnCollisionPrefab;
        public float LifeTime = 1f;

        void Start()
        {
            Destroy(gameObject, LifeTime);
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            HandleHit(coll.gameObject);

            if (OnCollisionPrefab != null)
                Instantiate(OnCollisionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        void OnCollision2D(Collision2D coll)
        {
            HandleHit(coll.gameObject);

            if (OnCollisionPrefab != null)
                Instantiate(OnCollisionPrefab, coll.contacts[0].point, transform.rotation);
            Destroy(gameObject);
        }


        private void HandleHit(GameObject obj)
        {
            var health = obj.gameObject.GetComponent<Health>();
            if (health == null)
                return;

            health.Deal(Damage);
        }

    }
}
