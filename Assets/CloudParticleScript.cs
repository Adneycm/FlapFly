using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudParticleScript : MonoBehaviour
{

    private ParticleSystem cloudParticle;
    private float timer = 0;
    public float spawnRate = 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cloudParticle = GetComponent<ParticleSystem>();

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            var particleMainSettings = cloudParticle.main;
            particleMainSettings.loop = true;
            cloudParticle.Play();
            cloudParticle.Stop();
            timer = 0;
        }
    }
}
