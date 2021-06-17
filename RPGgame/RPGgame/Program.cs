using System;


class Program
{
    static void Main(string[] args)
    {
        //try
        //{
            bool gameOpen = true;
            Game game = new Game();
            do // GAMELOOP QUE SE UTILIZA EN TODOS LOS VIDEOJUEGOS!!
            {
                gameOpen = game.Play();
            } while (gameOpen);
        //}
        /*catch (Exception)
        {
            Console.WriteLine("ERROR INESPERADO!");
        }*/
    }
}
// Acá tambien se coloca el anticheat y los dlcs
