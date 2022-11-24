using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace Guestbook
{
    public class Guestbook
    {
        //JSON filename variable
        private string filename = @"posts.json";
        private List<Post> posts = new List<Post>();

        public Guestbook()
        {   //Check if json file exists
            if (File.Exists(@"posts.json") == true)
            { // If true then read json
                string jsonString = File.ReadAllText(filename);
                //convert JSON string to .NET object
                posts = JsonSerializer.Deserialize<List<Post>>(jsonString);
            }
        }
        //Method to add post
        public Post addPost(Post post)
        {
            posts.Add(post);
            marshal();
            return post;
        }

        //method to delete post
        public int delPost(int index)
        {
            posts.RemoveAt(index);
            marshal();
            return index;
        }

        //method to get posts
        public List<Post> getPosts()
        {
            return posts;
        }

        private void marshal()
        {
            // Serialize all the objects and save to file
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }
    }

    public class Post
    {
        // fields
        private string g_name;
        private string g_text;
        public string G_name // property
        {
            set { this.g_name = value; } // set method
            get { return this.g_name; } // get method
        }

        public string G_text // property
        {
            set { this.g_text = value; } // set method
            get { return this.g_text; } // get method
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //new intance of class Guestbook
            Guestbook guestbook = new Guestbook();
            int i = 0;

            //while loop
            while (true)
            {
                //clear console
                Console.Clear(); 
                Console.CursorVisible = false;
                //welcome text
                Console.WriteLine("´Välkommen till gästboken!\n\n");

                //menu options
                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort inlägg\n");
                Console.WriteLine("X. Avsluta\n");

                //print all posts
                i = 0;
                foreach (Post post in guestbook.getPosts())
                {
                    Console.WriteLine("[" + i++ + "] " + post.G_name + " - " + post.G_text);
                }

                int inp = (int)Console.ReadKey(true).Key;
                //switch statement
                switch (inp)
                {
                    //case for writing new post
                    case '1':
                        //clear console
                        Console.Clear(); 
                        Console.CursorVisible = true;
                        //Input for name and text
                        Console.Write("Skriv namn: ");
                        string name = Console.ReadLine();
                        Console.Write("Skriv inlägg: ");
                        string text = Console.ReadLine();
                        //new Post object
                        Post obj = new Post();
                        obj.G_name = name;
                        obj.G_text = text;
                        //check if input is null/empty
                        if (!String.IsNullOrEmpty(name)) guestbook.addPost(obj); //add post
                        break;
                    //case for deleteing post
                    case '2':
                        //clear console
                        Console.Clear(); 
                        Console.CursorVisible = true;
                        //Print all posts
                        Console.Write("Inlägg:\n");
                        i = 0;
                        foreach (Post post in guestbook.getPosts())
                        {
                            Console.WriteLine("[" + i++ + "] " + post.G_name + " - " + post.G_text);
                        }
                        //Input for index
                        Console.Write("\nAnge index att radera: ");
                        string index = Console.ReadLine();
                        //delete chosen index
                        guestbook.delPost(Convert.ToInt32(index));
                        break;
                    //case to close
                    case 88:
                        Environment.Exit(0);
                        break;
                }

            }

        }
    }
}
