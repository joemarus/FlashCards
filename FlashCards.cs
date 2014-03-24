using System;
using System.IO;  // This is needed for the StreamReader class
using System.Collections.Generic;  // This is needed for the collection we will use

namespace JoeM.FlashCards
{
    // Here is a very simple class that will hold a single
    // flash card with a question and an answer.
    class FlashCard
    {
        public string Question;
        public string Answer;

        // This is a default constructor that puts in some
        // defaults when the object is created.
        public FlashCard()
        {
            Question = "Unknown";
            Answer = "Unknown";
        }
    }

    // Now for the main program...
    class Program
    {
        public static void Main()
        {
            // The StreamReader class is a class from the .NET Framework
            // that can read in text files line-by-line.
            // We are going to not give a path to the "cards.txt" that we
            // want to read from which assumes that it will be in the sasme
            // folder that this program is in.
            StreamReader sr = new StreamReader("cards.txt");
            // This is a simple collection of our flashcard objects.
            // Only FlashCards can go in this list.
            // We use a List instead of an array because we don't know
            // how many cards we will be loading.  Lists can keep growing.
            List<FlashCard> cards = new List<FlashCard>();

            // We've already seen how to use ReadLine.  StreamReader uses the
            // same method to read a line from the file.
            string str = sr.ReadLine();
            // If we reach the end of the file, then ReadLine will return a 
            // special value called "null" which means that there is nothing there.
            while (str != null)
            {
                FlashCard card = new FlashCard();  // create an empty Flashcard
                card.Question = str;  // set the Question to the first line read
                str = sr.ReadLine();  // read another line
                card.Answer = str;    // set the answer to the second line read
                cards.Add(card);      // add this flashcard to our collection
                str = sr.ReadLine();  // read the next line to see if there is more
            }
            sr.Close();  // we don't need the file open anymore

            Random rnd = new Random();  // lets make some random numbers

            Console.WriteLine("There are {0} flashcards.", cards.Count);   // hopefully we read in something!
            Console.WriteLine("\nWelcome to the Quiz!");
            string another = "y";
            while (another == "y")
            {
                int x = rnd.Next(cards.Count);
                Console.WriteLine("\nQuestion: {0}", cards[x].Question);
                Console.Write("Your answer: ");
                string answer = Console.ReadLine();
                if (answer == cards[x].Answer)
                {
                    Console.WriteLine("\nThat's correct!");
                }
                else
                {
                    Console.WriteLine("\nThat was wrong.  The correct asnwer is: {0}", cards[x].Answer);
                }
                Console.Write("\nDo you want another one? (y or n) ");
                another = Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}
