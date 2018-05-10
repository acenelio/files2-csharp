using System;
using System.Text;
using System.Collections.Generic;

namespace Course.Entities {
    class Post {

        public DateTime Moment { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; }

        public Post(DateTime moment, string title, string content, int likes) {
            Moment = moment;
            Title = title;
            Content = content;
            Likes = likes;
            Comments = new List<Comment>();
        }

        public void AddComments(params Comment[] comments) {
            foreach (Comment comment in comments) {
                Comments.Add(comment);
            }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Title);
            sb.AppendLine(Likes + " Likes - "  + Moment);
            sb.AppendLine(Content);
            sb.AppendLine("Comments:");
            foreach (Comment comment in Comments) {
                sb.AppendLine(comment.ToString());
            }
            return sb.ToString();
        }
    }
}
