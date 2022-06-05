using JobService.Model;
using JobService.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Service
{
    public class JobService : BaseService<Job>,IJobService
    {
        public IEnumerable<Job> GetAll(string term)
        {
            try
            {
                using UnitOfWork unitOfWord = new(new JobContext());
                return unitOfWord.Jobs.GetAll(term);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error is JobService in GetAll {e.Message} {e.StackTrace}");
                return new List<Job>();
            }
        }

        public IEnumerable<Job> GetAllById(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new JobContext());
                return unitOfWork.Jobs.GetAllById(id);
            }
            catch(Exception e)
            {

                return new List<Job>();
            }
        }

        public Job AddJob(Job entity, long userId)
        {
            if (entity == null)
            {
                return null;
            }
            Job job = new Job();
            try
            {
                using UnitOfWork unitOfWork = new(new JobContext());
                job.JobDescription = entity.JobDescription;
                job.ActivityLog = entity.ActivityLog;
                job.JobPosition = entity.JobPosition;
                job.JobConditions = entity.JobConditions;
                job.OwnerId = userId;
                unitOfWork.Jobs.Add(job);
                _ = unitOfWork.Complete();


                return entity;

            }



            catch (Exception e)
            {
                _logger.LogError($"Error in JobService in AddJob {e.Message} {e.StackTrace}");
                return null;
            }
        }

        public IEnumerable<Job> GetAllByPosition(string s)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new JobContext());

                return unitOfWork.Jobs.GetAllByPosition(s);
            }
            catch (Exception e)
            {
                return new List<Job>();
            }
        }

        public IEnumerable<Job> GetAll()
        {
            try
            {
                using UnitOfWork unitOfWord = new(new JobContext());
                return unitOfWord.Jobs.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error is JobService in GetAll {e.Message} {e.StackTrace}");
                return new List<Job>();
            }
            throw new NotImplementedException();
        }
    }
}
