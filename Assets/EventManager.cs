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

    //

    public static UraniumPickUp OnUraniumPickUpEvent;

    public static AutomaticFireUpgrade OnAutomaticFireUpgradeEvent;

    public static AutomaticGun OnAutomaticGunEvent;

    public static KillEnemy OnkillEnemyEvent;

    public static Ammo OnAmmoEvent;

    public static isClose OnIsCloseEvent;

    public static isNotClose OnIsNotCloseEvent;
}
