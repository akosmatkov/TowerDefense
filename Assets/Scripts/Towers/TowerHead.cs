﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Combat
{
    public class TowerHead : MonoBehaviour
    {
        [SerializeField] Transform projectileSpawnPosition = null;

        private void Start()
        {
            GetComponentInParent<Shooter>().SetProjectileSpawnPosition(projectileSpawnPosition);
        }
    }
}