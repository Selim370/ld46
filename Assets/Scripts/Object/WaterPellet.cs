﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPellet : MonoBehaviour {
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject waterSplashPrefab;
    [SerializeField] GameObject puddlePrefab;
    [SerializeField] Rigidbody2D body;
    [SerializeField] AudioClip waterShootSound;
    [SerializeField] AudioClip waterHitSound;
    [SerializeField] AudioClip waterEmptySound;

    public void Shoot(float angle) {
        if (playerData.water == 0) {
            SoundManager.Play(waterEmptySound);
            Instantiate(waterSplashPrefab, transform.position, Quaternion.identity, transform.parent);
            Destroy(gameObject);
        } else {
            SoundManager.Play(waterShootSound);
            angle += (Random.value - 0.5f) / 3;
            Vector2 velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * 350;
            body.velocity = velocity + Vector2.up * 90;
        }
    }

    public void OnExpire() {
        Instantiate(waterSplashPrefab, transform.position, Quaternion.identity, transform.parent);
        Instantiate(puddlePrefab, transform.position, Quaternion.identity, transform.parent);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Flammable flammable = collider.gameObject.GetComponentInChildren<Flammable>();
        if (flammable && flammable.IsOnFire()) {
            Instantiate(waterSplashPrefab, transform.position, Quaternion.identity, transform.parent);
            SoundManager.Play(waterHitSound);
            Destroy(gameObject);
        } else if (collider.gameObject.GetComponent<Car>() || collider.gameObject.GetComponent<Propane>()) {
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = body.velocity / 2;
        }
    }
}
