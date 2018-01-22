using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    const string menuHint = "\n" + "Type 'menu' at any time to go back";

    string[] level1Passwords = { "math", "program", "internet", "student", "team", "professor" };
    string[] level2Passwords = { "nuclear", "korea", "missile", "dictator", "north" };
    string[] level3Passwords = { "espionage", "alien", "international", "terrorism", "secrets" };

    int level;
    //Gamestate Win (simple) allow us to restrict the words used in WinScreen to "menu"
    enum GameState { MainMenu, Password, Win1, Win2, Win3, Win }; //3 pantallas de ganar para diferentes acciones
    GameState currentScreen = GameState.MainMenu;

    string password;
    bool changePassword;

    void Start()
    {
        ShowMainMenu();
    }

    void Update()
    {

    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Choose a target from the list");
        Terminal.WriteLine("the greater the number");
        Terminal.WriteLine("the more dangerous of the target");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 001 for MIT Main Server"); //Nos incribiremos en la institución
        Terminal.WriteLine("Press 002 for State Security Department of North Korea "); //Descubriremos si realmente cuentan con armas nucleares
        Terminal.WriteLine("Press 003 for The Pentagon"); //Confirmaremos la existencia de Aliens
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter the number of the server:");

        currentScreen = GameState.MainMenu;
        changePassword = true;
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("Be careful, They almost catch you");
            Terminal.WriteLine("Next time can be your last");
            Application.Quit();
        }
        else if (currentScreen == GameState.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == GameState.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == GameState.Win1) //condicion extra para cuando se gana el nivel 1
        {
            HackInsc(input);
        }
        else if (currentScreen == GameState.Win2)
        {
            HackNK(input);
        }
        else if (currentScreen == GameState.Win3)
        {
            HackPentagon(input);
        }
    }

    private void HackPentagon(string input)
    {
        Terminal.ClearScreen();
        switch (input)
        {
            case "1":
                Terminal.ClearScreen();
                Terminal.WriteLine(@"
▒▒▄▀▀▀▀▀▄▒▒▒▒▒▄▄▄▄▄▒▒▒
▒▐░▄░░░▄░▌▒▒▄█▄█▄█▄█▄▒
▒▐░▀▀░▀▀░▌▒▒▒▒▒░░░▒▒▒▒
▒▒▀▄░═░▄▀▒▒▒▒▒▒░░░▒▒▒▒
▒▒▐░▀▄▀░▌▒▒▒▒▒▒░░░▒▒▒▒

     
");

                Terminal.WriteLine(menuHint);
                currentScreen = GameState.Win;
                break;
            case "2":
                Terminal.ClearScreen();
                Terminal.WriteLine("too late they see you");
                Terminal.WriteLine(@"
       .-""""-.        .-""""-.
      /        \      /        \
     /_        _\    /_        _\
    // \      / \\  // \      / \\
    |\__\    /__/|  |\__\    /__/|
     \    ||    /    \    ||    /   
");

                currentScreen = GameState.Win;
                Terminal.WriteLine(menuHint);
                break;
            default:
                Terminal.WriteLine("Select  valid option");
                Terminal.WriteLine(menuHint);
                break;
        }
    }

    private void HackInsc(string input)
    {
        Terminal.WriteLine("Alumno " + input + " ha sido inscrito");
        Terminal.WriteLine("Favor de presentarse el lunes a clases");
        Terminal.WriteLine(@"
  __  __   ___   _____ 
 |  \/  | |_ _| |_   _|
 | |\/| |  | |    | |  
 | |  | |  | |    | |  
 |_|  |_| |___|   |_|  
");
        currentScreen = GameState.Win;
        Terminal.WriteLine(menuHint);
    }

    private void HackNK(string input)
    {
        switch (input)
        {
            case "1":
                Terminal.WriteLine(@"
    _.-^^---....,,--
 _--                  --_
<                        >)
|                         |
 \._                   _./
    ```--. . , ; .--'''
         | |   |
      .-=||  | |=-.
      `-=#$%&%$#=-'
         | ;  :|
_____.,-#%&$@%#&#~,._____");
                Terminal.WriteLine(menuHint);
                currentScreen = GameState.Win;
                break;
            case "2":
                Terminal.WriteLine("misiles inabilitados" +
                 @" __
            \ \_____
             [==_____>
            /_/
   __
   \ \_____       
    [==_____>
   /_/      
");
                Terminal.WriteLine(menuHint);
                currentScreen = GameState.Win;
                break;
            default:
                Terminal.WriteLine("Select  valid option");
                Terminal.WriteLine(menuHint);
                break;
        }
    }


    private void CheckPassword(string input) //Metodo modificado para agregar metodos especificos de nivel 
    {
        if (level == 1)
        {
            if (input == password)
            {
                DisplayWinScreen1();
            }
            else
            {
                AskForPassword();
            }
        }
        else if (level == 2)
        {
            if (input == password)
            {
                DisplayWinScreen2();
            }
            else
            {
                AskForPassword();
            }
        }
        else if (level == 3)
        {
            if (input == password)
            {
                DisplayWinScreen3();
            }
            else
            {
                AskForPassword();
            }
        }
    }

    private void DisplayWinScreen1()
    {
        currentScreen = GameState.Win1;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void DisplayWinScreen2()
    {
        currentScreen = GameState.Win2;
        Terminal.ClearScreen();
        ShowLevelReward();

    }

    private void DisplayWinScreen3()
    {
        currentScreen = GameState.Win3;
        Terminal.ClearScreen();
        ShowLevelReward();

    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Successful Connection" + "\n");
                Terminal.WriteLine("Bienvenido al Sistema de inscripciones del MIT");
                Terminal.WriteLine("Ingrese Su nombre");



                break;
            case 2:
                Terminal.WriteLine("Successful Connection" + "\n");
                Terminal.WriteLine("Bienvenido al Departamento de seguridad de Korea del Norte");
                Terminal.WriteLine("Oprima 1 para lanzar misiles nucleares");
                Terminal.WriteLine("Oprima 2 para inhabilitar misiles nucleares");

                break;
            case 3:
                Terminal.WriteLine("Successful Connection" + "\n");
                Terminal.WriteLine("Pentagono Servers." + "\n"
                    + "Only Authorized Personnel can access to this " +
                    "archives." + "\n" + "You want to open de door?");
                Terminal.WriteLine("Press 1 for yes");
                Terminal.WriteLine("Press 2 for no");

                break;
            default:
                Debug.LogError("Invalid level. Error 404.");
                break;
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidInput = (input == "1" || input == "2" || input == "3"
            ||
            input == "01" || input == "02" || input == "03" ||
            input == "001" || input == "002" || input == "003");

        if (isValidInput)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Hello, Mr. Bond, please select a server");
        }
        else if (input == "pikachu")
        {

            Terminal.WriteLine("Pika pika");
            Terminal.WriteLine(@"
░░░░█░▀▄░░░░░░░░░░▄▄███▀░░ 
░░░░█░░░▀▄░▄▄▄▄▄░▄▀░░░█▀░░ 
░░░░░▀▄░░░▀░░░░░▀░░░▄▀░░░░ 
░░░░░░░▌░▄▄░░░▄▄░▐▀▀░░░░░░ 
░░░░░░▐░░█▄░░░▄█░░▌▄▄▀▀▀▀█ 
░░░░░░▌▄▄▀▀░▄░▀▀▄▄▐░░░░░░█ 
░░░▄▀▀▐▀▀░░░░░░░▀▀▌▄▄▄░░░█ 
░░░█░░░▀▄░░░░░░░▄▀░░░░█▀▀▀
            ");

        }
        else
        {
            Terminal.WriteLine("Error #404");
            Terminal.WriteLine("Select a valid server");
        }
    }


    private void AskForPassword()
    {
        currentScreen = GameState.Password;
        Terminal.ClearScreen();
        if (changePassword)
        {
            SetRandomPassword();
        }
        Terminal.WriteLine("Enter the password. Hint: ");
        Terminal.WriteLine(password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        changePassword = false;

        switch (level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("That´s not a valid level. and you know it");
                Debug.LogError("try again");
                changePassword = true;
                break;
        }
    }
}