using System;
using System.Globalization;
using Course.Entities;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Course {
    class Program {
        static void Main(string[] args) {

            DateTime moment1 = DateTime.ParseExact("21/06/2018 13:05:44", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string title1 = "Traveling to New Zealand";
            string content1 = "I'm going to visit this wonderful country!";

            Comment c1 = new Comment("Have a nice trip");
            Comment c2 = new Comment("Wow that's awesome!");

            Post post1 = new Post(moment1, title1, content1, 12);
            post1.AddComments(c1, c2);

            DateTime moment2 = DateTime.ParseExact("28/07/2018 23:14:19", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string title2 = "Good night guys";
            string content2 = "See you tomorrow";

            Comment c3 = new Comment("Good night");
            Comment c4 = new Comment("May the Force be with you");

            Post post2 = new Post(moment2, title2, content2, 5);
            post2.AddComments(c3, c4);

            List<Post> list = new List<Post>() { post1, post2 };

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try {
                using (StreamWriter sw = File.CreateText(path)) {
                    string s = JsonConvert.SerializeObject(list, Formatting.Indented);
                    sw.WriteLine(s);
                    Console.WriteLine("Done!");
                }
            }
            catch (IOException e) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
