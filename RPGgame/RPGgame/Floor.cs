using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


class Floor
{
    public List<Enemy> enemies;
    public Floor(int maxEnemiesInFloor)
    {
        enemies = new List<Enemy>();
        Random random = new Random();
        int enemiesInFloor = random.Next(1, maxEnemiesInFloor);
        for (int i = 0; i<enemiesInFloor; i++)
		{
            enemies.Add(new Enemy("Goblin", 1000, 50, 20, 50));
        }
    }
    public Floor()
    {

    }

    public BinaryWriter Save(BinaryWriter bw)
    {
        bw.Write(enemies.Count);
        for (int i = 0; i < enemies.Count; i++)
        {
            bw = enemies[i].Save(bw);
        }
        return bw;
    }

    public BinaryReader Load(BinaryReader br)
    {
        int enemiesCount = br.ReadInt32();
        enemies = new List<Enemy>();
        for (int i = 0; i < enemiesCount; i++)
        {
            Enemy enemy = new Enemy();
            br = enemies[i].Load(br);
            enemies.Add(enemy);
        }
        return br;
    }

    public Player Fight(Player player)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            player = enemies[i].Attack(player);
        }
        enemies = player.Attack(enemies);

        List<Enemy> enemiesAlive = new List<Enemy>(); // lista de enemigos vivos.
        for (int i = 0; i < enemies.Count; i++) // Para eliminar enemigos que murieron luego del ataque del player.
        {       
            if(!enemies[i].IsDead())
            {
                enemiesAlive.Add(enemies[i]); // LO que hago aca es, si no estan muertos, agregalo a los enemigos vivos.
            }
        }
        enemies = enemiesAlive;
        return player;
    }
}
