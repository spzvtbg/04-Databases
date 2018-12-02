namespace Instagraph.DataProcessor
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using Instagraph.Data;
    using Instagraph.Models;
    using Instagraph.DataProcessor.ImportDtos;
    using Instagraph.DataProcessor.Constants;
    using System.Xml.Linq;
    using System.IO;
    using System.Xml.Serialization;
    using System.Xml;

    public class Deserializer
    {
        private static StringBuilder stringBuilder;

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            ICollection<Picture> pictures = new List<Picture>();

            stringBuilder = new StringBuilder();
            PictureDto[] picturesDto = JsonConvert.DeserializeObject<PictureDto[]>(jsonString);

            foreach (var picture in picturesDto)
            {
                bool IsNullOrWhiteSpace = string.IsNullOrWhiteSpace(picture.Path);
                bool IsUnique = context.Pictures.Any(x => x.Path == picture.Path);
                bool IsInvalidDecimalValue = picture.Size <= 0;

                if (IsNullOrWhiteSpace || IsUnique || IsInvalidDecimalValue)
                {
                    stringBuilder.AppendLine(Messages.Error);
                }
                else
                {
                    Picture newPicture = new Picture()
                    {
                        Path = picture.Path,
                        Size = picture.Size
                    };

                    pictures.Add(newPicture);
                    stringBuilder.AppendLine(string.Format(Messages.PictureSuccess, picture.Path));
                }
            }

            context.Pictures.AddRange(pictures);
            context.SaveChanges();

            return stringBuilder.ToString().Trim();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            ICollection<User> users = new List<User>();

            stringBuilder = new StringBuilder();
            UserDto[] usersDto = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            foreach (var user in usersDto)
            {
                bool IsUsernameNullOrWhiteSpace = string.IsNullOrWhiteSpace(user.Username);
                bool IsUsernameInMaxLength = user.Username?.Length > 30;
                bool IsPasswordNullOrWhiteSpace = string.IsNullOrWhiteSpace(user.Password);
                bool IsPasswordInMaxLength = user.Password?.Length > 20;
                bool Exists = users.Any(x => x.Username == user.Username);

                Picture picture = context.Pictures.SingleOrDefault(x => x.Path == user.ProfilePicture);

                if (IsUsernameNullOrWhiteSpace || IsUsernameInMaxLength || 
                    IsPasswordNullOrWhiteSpace || IsPasswordInMaxLength || 
                    Exists || picture == null)
                {
                    stringBuilder.AppendLine(Messages.Error);
                }
                else
                {
                    User newUser = new User()
                    {
                        Username = user.Username,
                        Password = user.Password,
                        ProfilePicture = picture
                    };

                    users.Add(newUser);
                    stringBuilder.AppendLine(string.Format(Messages.UserSuccess, user.Username));
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return stringBuilder.ToString().Trim();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            ICollection<UserFollower> followers = new List<UserFollower>();
            
            stringBuilder = new StringBuilder();
            FollowersDto[] followersDto = JsonConvert.DeserializeObject<FollowersDto[]>(jsonString);

            foreach (var obj in followersDto)
            {
                User user = context.Users.SingleOrDefault(x => x.Username == obj.User);
                User follower = context.Users.SingleOrDefault(x => x.Username == obj.Follower);

                if (user == null || follower == null || 
                    followers.Any(x => x.User.Username == obj.User && 
                        x.Follower.Username == obj.Follower))
                {
                    stringBuilder.AppendLine(Messages.Error);
                }
                else
                {
                    UserFollower newUserFollower = new UserFollower()
                    {
                        User = user,
                        Follower = follower
                    };

                    followers.Add(newUserFollower);

                    string message = string.Format(Messages.FollowerSuccess, obj.Follower, obj.User);
                    stringBuilder.AppendLine(message);
                }
            }

            context.UsersFollowers.AddRange(followers);
            context.SaveChanges();

            return stringBuilder.ToString().Trim();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            ICollection<Post> posts = new List<Post>();

            XDocument xmlData = XDocument.Parse(xmlString);
            IEnumerable<XElement> xElement = xmlData.Root.Elements();

            foreach (var item in xElement)
            {
                XElement[] elements = item.Elements().ToArray();
                if (elements.Length != 3)
                {
                    stringBuilder.AppendLine(Messages.Error);
                    continue;
                }

                string caption = elements[0]?.Value;
                string user = elements[1]?.Value;
                string picture = elements[2]?.Value;

                int? currentUser = context.Users.FirstOrDefault(x => x.Username == user)?.Id;
                int? currentPicture = context.Pictures.FirstOrDefault(x => x.Path == picture)?.Id;

                if (currentUser == null || currentPicture == null || string.IsNullOrWhiteSpace(caption))
                {
                    stringBuilder.AppendLine(Messages.Error);
                }
                else
                {
                    Post newPost = new Post()
                    {
                        Caption = caption,
                        UserId = currentUser.Value,
                        PictureId = currentPicture.Value
                    };

                    posts.Add(newPost);

                    string message = string.Format(Messages.PostSuccess, newPost.Caption);
                    stringBuilder.AppendLine(message);
                }
            }

            context.Posts.AddRange(posts);
            context.SaveChanges();

            return stringBuilder.ToString().Trim();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            ICollection<Comment> comments = new List<Comment>();
            stringBuilder = new StringBuilder();

            XDocument xmlData = XDocument.Parse(xmlString);
            IEnumerable<XElement> xElement = xmlData.Root.Elements();

            foreach (var item in xElement)
            {
                string content = item.Element("content")?.Value;
                string username = item.Element("user")?.Value;
                string postId = item.Element("post")?.Attribute("id")?.Value;

                Post currentPost = null;

                int id;
                if (int.TryParse(postId, out id) && id > 0)
                {
                   currentPost = context.Posts.SingleOrDefault(x => x.Id == id);
                }

                User currentUser = context.Users.SingleOrDefault(x => x.Username == username);

                if (currentUser == null || currentPost == null || string.IsNullOrWhiteSpace(content))
                {
                    stringBuilder.AppendLine(Messages.Error);
                }
                else
                {
                    Comment newComment = new Comment()
                    {
                        Content = content,
                        User = currentUser,
                        Post = currentPost
                    };

                    comments.Add(newComment);

                    string message = string.Format(Messages.CommentSuccess, content);
                    stringBuilder.AppendLine(message);
                }
            }

            context.Comments.AddRange(comments);
            context.SaveChanges();

            return stringBuilder.ToString().Trim();
        }
    }
}
