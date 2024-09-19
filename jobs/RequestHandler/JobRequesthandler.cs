using localhands.Jobs.ServiceProvider.Interface;
using localhands.Jobs.DTOs;

namespace localhands.Jobs.RequestHandler
{
    public class JobRequestHandler
    {
        private readonly IJobsServiceProvider _jobService;

        public JobRequestHandler(IJobsServiceProvider jobService)
        {
            _jobService = jobService;
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
            return Results.Created($"/jobs/{jobDto.Title}", jobDto);
        }
    }
}
