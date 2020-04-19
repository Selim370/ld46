﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SessionData", menuName = "Session Data")]
public class SessionData : ScriptableObject {
    public int peopleSaved;
    public int peopleDied;
    public int carsDestroyed;
    public int housesBurned;
    public int waterUsed;

    public void Reset() {
        peopleSaved = 0;
        peopleDied = 0;
        carsDestroyed = 0;
        housesBurned = 0;
        waterUsed = 0;
    }
}