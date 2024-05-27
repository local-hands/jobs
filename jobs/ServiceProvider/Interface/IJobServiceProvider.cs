using localhands.Jobs.DTOs;


namespace localhands.Jobs.ServiceProvider.Interface{


    public interface IJobsServiceProvider
    {
        Task<IEnumerable<JobCategoryDto>> GetJobsAsync();
        Task AddJobAsync(JobCategoryDto jobDto);
    }


}    