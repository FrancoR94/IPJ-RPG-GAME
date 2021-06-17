using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class Player
{
    private string name;
    private int maxLife;
    private int life;
    private int maxMana;
    private int mana;
    private Locations location;

    public Player() //Constructor vacío. Alojo el espacio en la memoria RAM para que el valor de la variable no sea NULO.
    {

    }
    public Player (string name, int maxLife, int maxMana, Locations spawnPoint) // Creas el constructor de Player
    {
        this.name = name;
        this.maxLife = maxLife;
        this.life = maxLife;
        this.maxMana = maxMana;
        this.mana = maxMana;
        location = spawnPoint;
    }

    public BinaryWriter Save(BinaryWriter bw)
    {
        bw.Write(name);
        bw.Write(maxLife);
        bw.Write(life);
        bw.Write(mana);
        bw.Write(maxMana);
        bw.Write((int)location);
        return bw;
    }
    public BinaryReader Load(BinaryReader br)
    {
        name = br.ReadString();   //Importante mantener el orden.
        maxLife = br.ReadInt32();
        life = br.ReadInt32();
        mana = br.ReadInt32();
        maxMana = br.ReadInt32();
        location = (Locations)br.ReadInt32();
        return br; //Para devolver donde se quedo el puntero de lectura.
    }
    public void Heal() // Cuando te curas por la posada, para volver 
    {
        life = maxLife;
    }
    public void Heal(int amount) // Sobrecarga de función: Sirve para funciones que harian lo mismo pero a partir de datos diferentes.
    {
        life += amount; // Cantidad que te puede curar por ejemplo una función
        if (life > maxLife) // Forzas para que se respete el límite máximo de cantidad de vida que se puede curar.
        {
            life = maxLife;
        }
    }
    public void RestoreMana()
    {
        mana = maxMana;
    }
    public void RestoreMana(int amount)
    {
        mana += amount;
        if(mana>maxMana)
        {
            mana = maxMana;
        }
    }
    public Locations GetLocation()
    {
        return location;
    }
    public void GoToTower()
    {
        location = Locations.Tower;
    }
    public void GoToInn()
    {
        location = Locations.Inn;
    }
    public void DoDamage(int amount)
    {
        life -= amount;
        if (life <=0)
        {
            Console.WriteLine("Moriste");
        }
    }
    public List<Enemy> Attack(List<Enemy>enemies)
    {
        Console.WriteLine("Select an enemy");
        for (int i = 0; i < enemies.Count; i++)
        {
            Console.WriteLine("Enemy N°: " + i);
            Console.WriteLine(enemies[i].GetStatus());
        }
        Console.WriteLine("Attack!");
        Console.WriteLine("Select an index from 0 to " + (enemies.Count -1));
        int input = Convert.ToInt32(Console.ReadLine());
        if (input >= 0 && input < enemies.Count)
        {
            enemies[input].DoDamage(10); // Numero aleatorio agregado ahora.
        }
        else
        {
            Console.WriteLine("MISS!");
        }
        return enemies;
    }
}

