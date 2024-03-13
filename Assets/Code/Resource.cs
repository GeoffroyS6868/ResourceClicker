using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Resource : MonoBehaviour
{
    public enum ResourceType
    {
        WOOD,
        STONE
    }

    public ResourceType Type;

    public ParticleSystem HitParticles;

    public delegate void ResourceAcquiredEventHandler(ResourceType type);

    public static event ResourceAcquiredEventHandler OnResourceAcquired;

    public void Farmed()
    {
        OnResourceAcquired?.Invoke(Type);
        if (HitParticles != null)
        {
            HitParticles.Play();
        }
    }
}
