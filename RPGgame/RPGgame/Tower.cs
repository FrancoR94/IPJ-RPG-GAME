using System;
using System.Collections.Generic;
using System.Text;


class Tower
{
    enum Options { Enter, Fight, Leave, GoToNextFloor, Error};
    private List<Floor> floors; // Una lista de una clase, lo estoy usando como una variable cualquiera
    private int lastVisitedFloor;
    private Options currentOption;
    enum OnEnterOption {Leave, Fight, Error };
    enum OnFinishFightOption { Leave, GoToNextFloor };
    public Tower(int floorsAmount)
    {
        floors = new List<Floor>();
        for (int i = 0; i < floorsAmount; i++)
        {
            floors.Add(new Floor(4));
        }
        lastVisitedFloor = 0;
        currentOption = Options.Enter;
    }

    public void StayInside(Player player)
    {
        switch (currentOption)
        {
            case Options.Enter:
                Enter();
                break;
            case Options.Fight:
                player = Fight(player);
                break;
            case Options.Leave:
                Leave();
                break;
            case Options.GoToNextFloor:
                GoToNextFloor();
                break;
            default:
                break;

        }
    }
    public void Enter()
    {
        Console.WriteLine("WELCOME TO THE TOWER");
        OnEnterOption onEnterOption;
        Console.WriteLine("Rest = 0   -   Leave = 1");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input >= 0 && input <= (int)OnEnterOption.Error)
        {
            onEnterOption = (OnEnterOption)input;
        }
        else
        {
            onEnterOption = OnEnterOption.Error;
        }
        switch ()
        {
            case Options.Rest:
                Rest(player);
                break;
            case Options.Leave:
                player.GoToTower();
                stayInsideInn = false;
                break;
            default:
                Console.WriteLine("ERROR!");
                break;
        }

    }
    public Player Fight(Player player)
    {
        floors[lastVisitedFloor].Fight(player);
        return player;
        if(floors[lastVisitedFloor].enemies.Count == 0)
        {
            lastVisitedFloor++;
            OnFinishFightOption onFinishFightOption;
        }
    }
    public void Leave(Player player)
    {
        player.GoToInn();
        return player;
    }
    public void GoToNextFloor()
    {

    }

}

