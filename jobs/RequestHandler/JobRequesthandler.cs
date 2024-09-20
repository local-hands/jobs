using localhands.Jobs.ServiceProvider.Interface;
using localhands.Jobs.DTOs;
using localhands.Jobs.Models;
using localhands.Jobs.Messaging.RabbitMQ;
using AutoMapper;

namespace localhands.Jobs.RequestHandler
{
    public class JobRequestHandler
    {
        private readonly IJobsServiceProvider _jobService;
         private readonly JobProducer _jobProducer;
         private readonly IMapper _mapper;

        public JobRequestHandler(IJobsServiceProvider jobService, JobProducer jobProducer, IMapper mapper)
        {
            _jobService = jobService;
            _jobProducer = jobProducer;
            _mapper = mapper;
        }

        public async Task<IResult> GetJobsAsync()
        {
            var jobs = await _jobService.GetJobsAsync();
            return Results.Ok(jobs);
        }


        public async Task<IResult> AddJobCategoryAsync(JobCategoryDto jobDto)
        {
            await _jobService.AddJobCategoryAsync(jobDto);
            return Results.Created($"/jobs/{jobDto.Name}", jobDto);
        }

        public async Task<IResult> AddJobAsync(JobDto jobDto)
        {
            await _jobService.AddJobAsync(jobDto);
             var job = _mapper.Map<JobDto, Job>(jobDto); 
            _jobProducer.SendJob(job); 
            return Results.Created($"/jobs/{jobDto.Title}", jobDto);
        }
    }
}
