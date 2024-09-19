using localhands.Jobs.DTOs;


namespace localhands.Jobs.ServiceProvider.Interface{


    public interface IJobsServiceProvider
    {
        Task<IEnumerable<JobCategoryDto>> GetJobsAsync();
        Task AddJobAsync(JobDto jobDto);
        Task AddJobCategoryAsync(JobCategoryDto jobDto);
    }


}    