using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using Massive;
using Oak;

namespace DynamicTests
{
    class Comments : DynamicRepository
    {
        public Comments()
        {
            Projection = d =>
            {
                var comment = new Comment(d);

                new Associations(comment);

                return comment;
            };
        }
    }

    class Blogs : DynamicRepository
    {
        public Blogs()
        {
            Projection = d =>
            {
                var blog = new Blog(d);

                new Associations(blog);

                return blog;
            };  
        }
    }

    class Comment : Gemini
    {
        Blogs blogs = new Blogs();

        public Comment(object dto)
            : base(dto)
        {
        }

        public IEnumerable<dynamic> Associates()
        {
            yield return new BelongsTo(blogs);
        }
    }

    class Blog : Gemini
    {
        Comments comments = new Comments();

        public Blog(object dto)
            : base(dto)
        {
            
        }

        public IEnumerable<dynamic> Associates()
        {
            yield return new HasMany(comments);
        }
    }

    class describe_7_associations : nspec
    {
        Seed seed;

        dynamic blogId;

        dynamic commentId;

        dynamic comment;

        dynamic blog;

        Comments comments;

        Blogs blogs;

        void before_each()
        {
            comments = new Comments();

            blogs = new Blogs();

            SetupSchema();
        }

        void specify_comment_belongs_to_blog()
        {
            comment = comments.Single(commentId);

            (comment.Blog().Title as string).should_be("Some Blog");
        }

        void specify_blog_as_many_comments()
        {
            blog = blogs.Single(blogId);

            (blog.Comments().First().Text as string).should_be("Comment 1");
        }

        void SetupSchema()
        {
            seed = new Seed();

            seed.PurgeDb();

            seed.CreateTable("Blogs", new dynamic[] 
            {
                new { Id = "int", Identity = true, PrimaryKey = true },
                new { Title = "nvarchar(255)" },
                new { Body = "nvarchar(max)" }
            }).ExecuteNonQuery();

            seed.CreateTable("Comments", new dynamic[] 
            {
                new { Id = "int", Identity = true, PrimaryKey = true },
                new { BlogId = "int", ForeignKey = "Blogs(Id)" },
                new { Text = "nvarchar(1000)" }
            }).ExecuteNonQuery();

            blogId = new { Title = "Some Blog", Body = "Lorem Ipsum" }.InsertInto("Blogs");

            commentId = new { BlogId = blogId, Text = "Comment 1" }.InsertInto("Comments");
        }
    }
}
