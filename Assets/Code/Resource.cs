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

    public void Farmed(Vector2 position)
    {
        OnResourceAcquired?.Invoke(Type);
        if (HitParticles != null)
        {
            var TempHitParticles = Instantiate(HitParticles);
            TempHitParticles.transform.position = position;
            TempHitParticles.Play();
            Destroy(TempHitParticles.gameObject, TempHitParticles.main.duration * 2);
        }
    }
}
