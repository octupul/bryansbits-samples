using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMLib.RapidPrototyping.Generators;

namespace Hub_Feeder.Model
{
    public class Comment
    {
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public int LengthOfConversation { get; set; }
        public string User { get; set; }
        public static Comment GetRandomSentence()
        {

            Random rand = new Random();
            WordGenerator generator = new WordGenerator();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rand.Next(5,20); i++)
            {
                sb.Append(generator.Next());
                sb.Append(" ");
                if(rand.Next(0,5) == 0)
                    sb.Append("the ");
                if (rand.Next(0, 6) == 0)
                    sb.Append("a ");
            }
            Comment newComment = new Comment();
            newComment.Text = sb.ToString() ;
            newComment.TimeStamp = DateTime.Now;
            newComment.LengthOfConversation = rand.Next(500, 1500) * newComment.Text.Split(' ').Length;
            return newComment;
        }
    }
}
