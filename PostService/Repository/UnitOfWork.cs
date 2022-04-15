using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostContext _context;

        private Dictionary<string, dynamic> _repositories;

        public UnitOfWork(PostContext context)
        {
            _context = context;
            Posts = new PostRepository(_context);
            Reactions = new ReactionRepository(_context);
            Comments = new CommentsRepository(_context);
        }

        public IPostRepository Posts { get; private set; }

        public IReactionRepository Reactions { get; private set; }
        
        public ICommentsRepository Comments { get; private set; }
        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            string type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            Type repositoryType = typeof(BaseRepository<>);

            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

            return (IBaseRepository<TEntity>)_repositories[type];
        }

        public PostContext Context
        {
            get { return _context; }
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
