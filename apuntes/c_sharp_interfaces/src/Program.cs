using System;
using System.Globalization;
using controllers;
using models;
using repositories;
using utils;

class Program
{
    static void Main()
    {
        // Fachade
        var bookRepository = new BookRepositoryImpl();
        var bookController = new BookControllerImpl(bookRepository);
        var menuConsole = new ConsoleMenu(bookController);

        menuConsole.Start();
    }
}

