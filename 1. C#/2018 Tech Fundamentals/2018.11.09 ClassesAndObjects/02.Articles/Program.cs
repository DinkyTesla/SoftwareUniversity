using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    public class Program
    {
        public class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }

            public string Content { get; set; }

            public string Author { get; set; }

            public void Edit(string content)
            {
                this.Content = content;
            }
            public void ChangeAuthor(string author)
            {
                this.Author = author;
            }
            public void Rename(string title)
            {
                this.Title = title;
            }
            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }

        public static void Main()
        {

            var givenList = new List<string>(Console.ReadLine()
                .Split(", ")
                .ToList());

            string title = givenList[0];
            string content = givenList[1];
            string author = givenList[2];

            Article article = new Article(title, content, author);

            int inputRolls = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputRolls; i++)
            {
                var newList = new List<string>(Console.ReadLine()
                .Split(": ")
                .ToList());

                if (newList.Contains("Edit"))
                {
                    article.Edit(newList[1]);
                } 
                else if (newList.Contains("Rename"))
                {
                    article.Rename(newList[1]);
                }
                if (newList.Contains("ChangeAuthor"))
                {
                    article.ChangeAuthor(newList[1]);
                }
            }
            //Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            Console.WriteLine(article);
        }
    }
}
