using System.Collections.Generic;
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Amount of lives before the players loses
        int lives = 10;

        // String to hold the current letter that has been guessed
        char currentGuess = 'e';

        // Creates an array for all of the words (They were chosen from the top 3000 most common and trimmed down to only ones that are longer than 3 characters)
        string[] wordList = File.ReadAllLines(@"wordlist.txt");

        // Creates a random number generator and picks a random number
        Random generator = new Random();
        int e = generator.Next(3000);

        // Creates a list to hold all of the letters that the player has guessed
        List<char> guessedLetters = new List<char>();

        // Creates an int to know how many characters the word contains
        int lettersRemaining = wordList[e].Length;

        // Runs a loop as long as the player still has lives remaining and they haven't guessed the word
        while (lives > 0 && lettersRemaining > 0)
        {
            Console.WriteLine("Guesses remaining: " + lives);
            Console.WriteLine("Word:");
            foreach (char letter in wordList[e])
            {
                if (guessedLetters.Contains(letter))
                {
                    Console.Write(letter);
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Guessed letters");
            foreach (char guessedLetter in guessedLetters)
            {
                Console.Write(guessedLetter);
                Console.Write(", ");
            }

            Console.WriteLine("\n Write a letter:");

            bool charInput = char.TryParse(Console.ReadLine(), out currentGuess);


            while (!guessedLetters.Contains(currentGuess) && Regex.IsMatch(currentGuess.ToString(), @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Please enter a valid character");
                Console.WriteLine("Write a letter:");

                charInput = char.TryParse(Console.ReadLine(), out currentGuess);
            }

        }
    }
}