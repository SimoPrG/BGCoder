using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        BigInteger firstPlayerMatchScore = 0;
        BigInteger secondPlayerMatchScore = 0;
        long firstPlayerGamesWon = 0;
        long secondPlayerGamesWon = 0;
        bool firstPlayerWinsX = false;
        bool secondPlayerWinsX = false;

        long N = long.Parse(Console.ReadLine());

        for (long i = 0; i < N; i++)
        {
            string[] playersCards = new string[6];

            for (int j = 0; j < 6; j++)
            {
                playersCards[j] = Console.ReadLine();
            }

            if (firstPlayerWinsX || secondPlayerWinsX)
            {
                continue;
            }

            int firstPlayerHandStrenght = 0;
            bool firstPlayerXCardDrown = false;
            for (int j = 0; j < 3; j++) //check first players cards
            {
                switch (playersCards[j])
                {
                    case "2": firstPlayerHandStrenght += 10; break;
                    case "3": firstPlayerHandStrenght += 9; break;
                    case "4": firstPlayerHandStrenght += 8; break;
                    case "5": firstPlayerHandStrenght += 7; break;
                    case "6": firstPlayerHandStrenght += 6; break;
                    case "7": firstPlayerHandStrenght += 5; break;
                    case "8": firstPlayerHandStrenght += 4; break;
                    case "9": firstPlayerHandStrenght += 3; break;
                    case "10": firstPlayerHandStrenght += 2; break;
                    case "A": firstPlayerHandStrenght += 1; break;
                    case "J": firstPlayerHandStrenght += 11; break;
                    case "Q": firstPlayerHandStrenght += 12; break;
                    case "K": firstPlayerHandStrenght += 13; break;
                    case "X": firstPlayerXCardDrown = true; break;
                    case "Y": firstPlayerMatchScore -= 200; break;
                    case "Z": firstPlayerMatchScore *= 2; break;
                }
            }

            int secondPlayerHandStrenght = 0;
            bool secondPlayerXCardDrown = false;
            for (int j = 3; j < 6; j++) //check second players cards
            {
                switch (playersCards[j])
                {
                    case "2": secondPlayerHandStrenght += 10; break;
                    case "3": secondPlayerHandStrenght += 9; break;
                    case "4": secondPlayerHandStrenght += 8; break;
                    case "5": secondPlayerHandStrenght += 7; break;
                    case "6": secondPlayerHandStrenght += 6; break;
                    case "7": secondPlayerHandStrenght += 5; break;
                    case "8": secondPlayerHandStrenght += 4; break;
                    case "9": secondPlayerHandStrenght += 3; break;
                    case "10": secondPlayerHandStrenght += 2; break;
                    case "A": secondPlayerHandStrenght += 1; break;
                    case "J": secondPlayerHandStrenght += 11; break;
                    case "Q": secondPlayerHandStrenght += 12; break;
                    case "K": secondPlayerHandStrenght += 13; break;
                    case "X": secondPlayerXCardDrown = true; break;
                    case "Y": secondPlayerMatchScore -= 200; break;
                    case "Z": secondPlayerMatchScore *= 2; break;
                }
            }

            if (firstPlayerXCardDrown)
            {
                if (secondPlayerXCardDrown)
                {
                    firstPlayerMatchScore += 50;
                    secondPlayerMatchScore += 50;
                    firstPlayerXCardDrown = false;
                    secondPlayerXCardDrown = false;
                }
                else
                {
                    firstPlayerWinsX = true;
                    firstPlayerXCardDrown = false;
                    continue;
                }
            }

            if (secondPlayerXCardDrown)
            {
                secondPlayerWinsX = true;
                secondPlayerXCardDrown = false;
                continue;
            }

            if (firstPlayerHandStrenght > secondPlayerHandStrenght)
            {
                firstPlayerGamesWon++;
                firstPlayerMatchScore += firstPlayerHandStrenght;
            }
            else if (firstPlayerHandStrenght < secondPlayerHandStrenght)
            {
                secondPlayerGamesWon++;
                secondPlayerMatchScore += secondPlayerHandStrenght;
            }
        }

        if (firstPlayerWinsX)
        {
            Console.WriteLine("X card drawn! Player one wins the match!");
            return;
        }

        if (secondPlayerWinsX)
        {
            Console.WriteLine("X card drawn! Player two wins the match!");
            return;
        }

        if (firstPlayerMatchScore > secondPlayerMatchScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", firstPlayerMatchScore);
            Console.WriteLine("Games won: {0}", firstPlayerGamesWon);
            return;
        }
        else if (firstPlayerMatchScore < secondPlayerMatchScore)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", secondPlayerMatchScore);
            Console.WriteLine("Games won: {0}", secondPlayerGamesWon);
            return;
        }
        else
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", firstPlayerMatchScore);
            return;
        }
    }
}