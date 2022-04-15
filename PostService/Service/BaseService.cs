﻿using Microsoft.Extensions.Logging;
using PostService.Configuration;
using PostService.Model;
using PostService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public class BaseService<TEntity> where TEntity : class
    {
        protected readonly ProjectConfiguration _configuration;
        protected readonly ILogger _logger;

        public BaseService()
        {

        }

        public BaseService(ProjectConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseService(ProjectConfiguration configuration, ILogger<BaseService<TEntity>> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public virtual TEntity Get(long id)
        {
            try
            {
                using UnitOfWork unitWork = new(new PostContext());
                TEntity entity = unitWork.GetRepository<TEntity>().Get(id);

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Get Method { e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public virtual TEntity Add(TEntity entity)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new PostContext());

                unitOfWork.GetRepository<TEntity>().Add(entity);
                _ = unitOfWork.Complete();

                return entity;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Add Method { e.Message} in { e.StackTrace}");
                return null;
            }
        }

        public virtual bool Update(long id, TEntity ent)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new PostContext());

                TEntity entity = Get(id);

                if (entity == null)
                {
                    unitOfWork.GetRepository<TEntity>().Add(ent);
                }

                unitOfWork.GetRepository<TEntity>().Update(ent);
                _ = unitOfWork.Complete();

                return true;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Add Method { e.Message} in { e.StackTrace}");
                return false;
            }
        }

        public virtual bool Delete(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new PostContext());

                TEntity entity = unitOfWork.GetRepository<TEntity>().Get(id);

                (entity as Entity).Deleted = true;

                unitOfWork.GetRepository<TEntity>().Update(entity);
                _ = unitOfWork.Complete();

                return true;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Add Method { e.Message} in { e.StackTrace}");
                return false;
            }
        }
    }
}
