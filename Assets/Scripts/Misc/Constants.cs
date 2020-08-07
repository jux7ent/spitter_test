using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Constants {
    public const int TOTAL_LEVELS_COUNT = 15;

    public static class Tags {
        public const string DEATH_ZONE = "DeathZone";
        public const string FINISH = "Finish";
        public const string MUST_GRAB = "MustGrab";
        public const string JOINT_POINT = "JointPoint";
        public const string LINE = "Line";
    }

    public static class Scenes {
        public const string MENU_SCENE = "MenuScene";
        public const string GAME_SCENE = "GameScene";
    }
}
