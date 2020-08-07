using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings {
    public int currentLevel = 0;
    public bool soundEffects = true;
    public bool music = true;
    public int fridgeItemsCount = 3;

    private static Settings _settings;
    private const string SETTINGS_PLAYER_PREFS = "#PPSETTINGS#";
    
    private Settings() {}
    
    public event Action<Settings> OnSavingSettings;
    
    public static Settings instance {
        get {
            if (_settings == null) {
                _settings = ExtentedPlayerPrefs.GetObject<Settings>(SETTINGS_PLAYER_PREFS, new Settings());
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
