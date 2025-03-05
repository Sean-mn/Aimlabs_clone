using System;

public class Define
{
    public class Tags
    {
        public const string Player = "Player";
        public const string Target = "Target";
    }

    public enum Layers
    {
        Ground,
        Player,
        Target,
    }

    public enum Scene
    {
        Menu = 0,
        Play = 1,
        Rank = 2,
    }

    [Flags]
    public enum GameState
    {
        Menu,
        Playing,
        GameOver,
    }

    public enum GameLevel
    {
        Easy,
        Normal,
        Hard,
    }
}