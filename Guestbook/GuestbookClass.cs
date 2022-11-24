using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
}
