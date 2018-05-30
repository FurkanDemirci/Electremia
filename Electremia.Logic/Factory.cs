using System;
using System.Collections.Generic;
using System.Text;
using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Microsoft.Extensions.Configuration;

namespace Electremia.Logic
{
    /// <summary>
    /// Factory class that initializes wich context class to use for the services.
    /// </summary>
    public class Factory
    {
        //private readonly string _connectionString;
        private readonly string _context;

        public Factory()
        {
            _context = null;
        }

        public Factory(IConfiguration config)
        {
            _context = config.GetSection("Database")["Type"];
        }

        public AccountServices AccountService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new AccountServices(new AccountRepository(new AccountSqlContext()));
                default: 
                    return new AccountServices(new AccountRepository(new AccountMemoryContext()));
            }
        }

        public JobServices JobService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new JobServices(new JobRepository(new JobSqlContext()));
                default: 
                    return new JobServices(new JobRepository(new JobMemoryContext()));
            }
        }

        public SchoolServices SchoolService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new SchoolServices(new SchoolRepository(new SchoolSqlContext()));
                default: 
                    return new SchoolServices(new SchoolRepository(new SchoolMemoryContext()));
            }
        }

        public FriendServices FriendService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new FriendServices(new RelationshipRepository(new RelationshipSqlContext()));
                default: 
                    return new FriendServices(new RelationshipRepository(new RelationshipMemoryContext()));
            }
        }

        public PostServices PostService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new PostServices(new PostRepository(new PostSqlContext()));
                default:
                    return new PostServices(new PostRepository(new PostMemoryContext()));
            }
        }

        public ProductServices ProductService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new ProductServices(new ProductRepository(new ProductSqlContext()));
                default:
                    return new ProductServices(new ProductRepository(new ProductMemoryContext()));
            }
        }

        public PictureServices PictureService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new PictureServices(new PictureRepository(new PictureSqlContext()));
                default:
                    return new PictureServices(new PictureRepository(new PictureMemoryContext()));
            }
        }

        public LikeServices LikeService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new LikeServices(new LikeRepository(new LikeSqlContext()));
                default:
                    return new LikeServices(new LikeRepository(new LikeMemoryContext()));
            }
        }

        public CommentServices CommentService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new CommentServices(new CommentRepository(new CommentSqlContext()));
                default:
                    return new CommentServices(new CommentRepository(new CommentMemoryContext()));
            }
        }
    }
}
