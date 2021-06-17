using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


class Game
{
    // Generalmente esta constituido por el menu, el gameplay y el lobby.
    //En nuestro caso el gameplay esta constituido por el player, una posada y un inn.
    // La torre esta constituida por pisos.
    //Nuestros pisos estan constituidos por enemigos.
    private Player player;
    private Inn inn;
    private Tower tower;
    
    public Game()
    {
        bool load = false; //Si coloco true, como no tengo ningun archivo guardado me dice que el player es null
        if(load)
        {
            LoadGame();
        }
        else
        {
            StartNewGame();
        }
    }
    public void LoadGame()
    {
        Load();
        inn = new Inn(); //Para crear el espacio para el Inn, sino sería nulo porque en Load no esta inicializado.
    }
    public void StartNewGame()
    {
        player = new Player("pepe", 100, 20, Locations.Inn);
        inn = new Inn();
        tower = new Tower(10);
        //Save(); // Después de llamar a todos los contructores se guarde esto.
    }
    public bool Play()
    {
        switch (player.GetLocation())
        {
            case Locations.Inn:
                player = inn.Stay(player);
                break;
            case Locations.Tower:
                player = tower.StayInside(player);
                break;
            default:
                Console.WriteLine("ERROR!");
                break;
        }
        return true;
    }

    public void Save()
    {
        Stream save = File.Open("MySave.sav", FileMode.OpenOrCreate); // Archivo en si mismo
        BinaryWriter bw = new BinaryWriter(save); // El stream de escritura de archivo. Es como un usuario con el archivo abierto escribiendolo.
        bw = player.Save(bw);
        bw = tower.Save(bw);
        bw.Close(); // Se cierran ambos archivos! ( el writer )
        save.Close(); // Se cierran ambos archivos! ( el archivo )
    }

    public void Load()
    {
        if (File.Exists("MySave.sav")) // Para preguntar si tengo algun archivo guardado previamente.
        {
            Stream file = File.Open("MySave.sav", FileMode.Open);

            BinaryReader br = new BinaryReader(file);
            player = new Player();
            br = player.Load(br); // el player solo se va a asignar todos los datos.
            tower = new Tower();
            br = tower.Load(br);
            br.Close();
            file.Close();
        }
        else
        {
            Console.WriteLine("No existe ninguna partida guardada");
        }
    }

}

