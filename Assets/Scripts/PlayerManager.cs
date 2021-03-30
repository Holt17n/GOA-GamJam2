using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool alive = true;

    #region Singleton

    public static PlayerManager instance;

    void Awake ()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public void changePlayerStatus(bool death)
    {
        alive = death;
    }

    public bool getPlayerStatus()
    {
        return alive;
    }
}
