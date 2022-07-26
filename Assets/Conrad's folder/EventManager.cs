using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void UraniumPickUp();

    public delegate void AutomaticFireUpgrade();

    public delegate void AutomaticGun();

    public delegate void KillEnemy(string enemySpecifier);

    public delegate void Ammo();

    public delegate void isClose();

    public delegate void isNotClose();

    public delegate void DoorOveride();

    public delegate void LevelOneKeyCard();

    public delegate void IncreaseLevel();

    public delegate void GreenKeyCard();

    public delegate void RedKeyCard();

    public delegate void BlueKeyCard();

    //

    public static UraniumPickUp OnUraniumPickUpEvent;

    public static AutomaticFireUpgrade OnAutomaticFireUpgradeEvent;

    public static AutomaticGun OnAutomaticGunEvent;

    public static KillEnemy OnkillEnemyEvent;

    public static Ammo OnAmmoEvent;

    public static isClose OnIsCloseEvent;

    public static isNotClose OnIsNotCloseEvent;

    public static DoorOveride OnDoorOverideEvent;

    public static LevelOneKeyCard OnLevelOneKeyCardEvent;

    public static IncreaseLevel OnIncreaseLevelEvent;

    public static GreenKeyCard OnGreenKeyCardEvent;

    public static BlueKeyCard OnBlueKeyCardEvent;

    public static RedKeyCard OnRedKeyCardEvent;
}
