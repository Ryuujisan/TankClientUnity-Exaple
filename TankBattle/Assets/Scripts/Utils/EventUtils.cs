﻿using System.Collections.Generic;
using Protocol;
using UnityEngine;

public class EventUtils
{
    public static void UpdatePlayer(UpdateGamePlay updateGameplay)
    {
        List<Player> players = new List<Player>();

        for (int i = 0; i < updateGameplay.player.Count; i++)
        {
            Player player = new Player();
            player.position = new Vector3(updateGameplay.player[i].positionX, updateGameplay.player[i].postionY);
            player.id = updateGameplay.player[i].id;
            player.course = updateGameplay.player[i].tankCourse;
            player.barrelCourse = updateGameplay.player[i].barrelCourse;
            player.hp = updateGameplay.player[i].hp;
            players.Add(player);
        }

        GameManager.GamePlay.UpdatePlayer(players);
    }

    public static void Hit()
    {

    }

    public static void Dead()
    {

    }

    public static void BulletFire(BulletFire bulletFire)
    {
        Vector3 startPosition = new Vector3(bulletFire.posX, bulletFire.posY);
        Vector3 velocity = new Vector3(bulletFire.velX, bulletFire.velY);

        float range = bulletFire.range;
        int id = bulletFire.bulletID;

        Balls ball = GameManager.PoolMenager.BallPool.GetPool(id);
        ball.SetBall(startPosition, velocity, range);
    }
}
