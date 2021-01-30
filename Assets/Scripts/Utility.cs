using UnityEngine;

public static class Utility
{
    private static Transform player;
    public static Transform PlayerPos => (player) ? player : Getplayer();

    private static Transform Getplayer()
    {
        return player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
