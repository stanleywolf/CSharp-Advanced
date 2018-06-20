using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWarsStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstAllCards = new Queue<string>(Console.ReadLine().Split());
            var secondAllCards = new Queue<string>(Console.ReadLine().Split());

            
            int moves = 0;
            bool gameOver = false;
            
             while (moves < 1000000 && firstAllCards.Count > 0 && secondAllCards.Count > 0 && !gameOver)
             {
                 moves++;
                var firstCard = firstAllCards.Dequeue();
                var secondCard = secondAllCards.Dequeue();

                var digitFirst = TakeDigit(firstCard);
                var digitSecond = TakeDigit(secondCard);
              
                if (digitFirst > digitSecond)
                {
                        firstAllCards.Enqueue(firstCard);
                        firstAllCards.Enqueue(secondCard);             
                }
                else if (digitSecond > digitFirst)
                {
                        secondAllCards.Enqueue(secondCard);
                        secondAllCards.Enqueue(firstCard);
                }
                else
                {
                    var cardHands = new List<string>{firstCard,secondCard};
                    while (!gameOver)
                    {
                        if (firstAllCards.Count >= 3 && secondAllCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int i = 0; i < 3; i++)
                            {
                                var firstHandCard = firstAllCards.Dequeue();
                                var secondHandCard = secondAllCards.Dequeue();
                                firstSum += GetChar(firstHandCard);
                                secondSum += GetChar(secondHandCard);
                                cardHands.Add(firstHandCard);
                                cardHands.Add(secondHandCard);
                            }
                            if (firstSum > secondSum)
                            {
                                AddCardsToWiner(cardHands, firstAllCards);
                                break;
                            }
                            else if (secondSum > firstSum)
                            {
                                AddCardsToWiner(cardHands,secondAllCards);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }

            }
            string winner = String.Empty;
            if (firstAllCards.Count == secondAllCards.Count)
            {
                winner = "Draw";
            }
            else if (firstAllCards.Count > secondAllCards.Count)
            {
                winner = "First player wins";
            }
            else
            {
                winner = "Second player wins";
            }
            Console.WriteLine($"{winner} after {moves} turns");
        }

        private static void AddCardsToWiner(List<string> cardHands, Queue<string> firstAllCards)
        {
            foreach (var card in cardHands.OrderByDescending(c => TakeDigit(c)).ThenByDescending(c => GetChar(c)))
            {
                firstAllCards.Enqueue(card);
            }
        }

        private static int TakeDigit(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        private static int GetChar(string card)
        {
            return card[card.Length - 1];
        } 
    }
}
