﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int brickCount = 0;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;


    // Use this for initialization
    void Start() {
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable) {
            brickCount++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isBreakable) {
            HandleHits();
        }

    }

    void HandleHits() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            brickCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        } else {
            LoadSprites();
        }
    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

    }

    // TODO Remove this method once we can actually win!
    void SimulateWin() {
        LevelManager.LoadNextLevel();
    }
}
