using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void SpawnParticle(GameObject particle, Vector3 pos, Quaternion rot, bool autoDestroy = true, float destroyTime = 2)
    {
        if (particle)
        {
            var p = Instantiate(particle, pos, rot);
            if (autoDestroy)
            {
                Destroy(p, destroyTime);
            }
        }
    }

}
