﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public float lifeTime;

    private ParticleSystem particles;
    private AudioSource audioSource;
    private bool justSpawned = true;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    protected virtual void OnEnable()
    {
        if (!justSpawned)
        {
            if (particles)
            {
                particles.Play();
            }
            if (audioSource)
            {
                audioSource.Play();
            }
            StartCoroutine(EndLifeTime());
        }
        else
        {
            justSpawned = false;
        }
    }

    private IEnumerator EndLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}
