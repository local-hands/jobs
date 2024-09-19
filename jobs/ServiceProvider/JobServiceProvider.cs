using localhands.Jobs.Models;
using localhands.Jobs.DTOs;
using AutoMapper;
using MongoDB.Driver;
using localhands.Jobs.ServiceProvider.Interface;
using localhands.Jobs.ServiceProvider;

namespace localhands.Jobs.ServiceProvider
{
    

    public class JobsServiceProvider : IJobsServiceProvider
    {
        private readonly IMongoCollection<JobCategory> _jobCategory;
        private readonly IMongoCollection<Job> _job;
        private readonly IMapper _mapper;

        public JobsServiceProvider(DbServiceProvider context, IMapper mapper)
        {
            _jobCategory = context.JobCategory;
            _job = context.Jobs;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobCategoryDto>> GetJobsAsync()
        {
            var jobs = await _jobCategory.Find(job => true).ToListAsync();
            return _mapper.Map<IEnumerable<JobCategoryDto>>(jobs);
        }

        public async Task AddJobCategoryAsync(JobCategoryDto jobDto)
        {
            var job = _mapper.Map<JobCategory>(jobDto);
            await _jobCategory.InsertOneAsync(job);
            
        }


        public async Task AddJobAsync(JobDto jobDto)
        {
            var job = _mapper.Map<Job>(jobDto);
            await _job.InsertOneAsync(job);
        }
    }
}
