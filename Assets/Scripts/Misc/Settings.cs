using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings {
    public int lastPassedLevelId = -1;
    public int currentLevel = 0;
    public bool soundEffects = true;
    public bool music = true;
    public bool cameraShaking = true;
    public bool adsRemoved = false;
    public int[] starsForLevelId = new int[200];
    public float[] bestTimeForLevelId; // no init here, because needs no default values

    private static Settings _settings;
    private const string SETTINGS_PLAYER_PREFS = "#PPSETTINGS#";
    
    private Settings() {}
    
    public event Action<Settings> OnSavingSettings;
    
    public static Settings instance {
        get {
            if (_settings == null) {
                _settings = ExtentedPlayerPrefs.GetObject<Settings>(SETTINGS_PLAYER_PREFS, new Settings());

                if (_settings.bestTimeForLevelId == null) {
                    _settings.bestTimeForLevelId = new float[200];
                    for (int i = 0; i < 200; ++i) {
                        _settings.bestTimeForLevelId[i] = 10000;
                    }

                    _settings.save();
                }
            }
            return _settings;
        }
    }
    
    public static Settings GetResettedInstance() {
        _settings = null;
        return instance;
    }

    public void save(bool instant=false) {
        if (_settings != null) {
            ExtentedPlayerPrefs.SetObject<Settings>(SETTINGS_PLAYER_PREFS, _settings, instant);
            OnSavingSettings?.Invoke(_settings);
        }
    }
}
