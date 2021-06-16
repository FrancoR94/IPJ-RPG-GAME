using System;
using System.Collections.Generic;
using System.Text;


public class Enemy
{
    private string name;
    private int maxLife;
    private int life;
    private int maxMana;
    private int Mana;
    private int MinAttack;
    private int MaxAttack;
    public Enemy(string name, int maxLife, int maxMana, int minaAttack, int maxAttack) // Creas el constructor de Player
    {
        this.name = name;
        this.maxLife = maxLife;
        this.life = maxLife;
        this.maxMana = maxMana;
        this.Mana = maxMana;
        this.MinAttack = minAttack;
        this.maxAttack = maxAttack;
    }
    public Player Attack (Player player)
    {
        player.DoDamage(attack);
        return player;
    }
    public string GetStatus()
    {
        string status = "";
        status += "Name: " + name;
        status += "Life: " + life \n
        return status;
    }
    public void DoDamage(int amount)
    {
        life -= amount;
        if (life <= 0)
        {
            Console.WriteLine("MORISTE PUTO" + name);
        }
    }
    public bool IsDead()
    {

    }
}

