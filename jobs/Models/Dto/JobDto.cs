namespace localhands.Jobs.DTOs
{
    public class JobDto
    {
        public string Id { get; set; }  = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }  = string.Empty;
        public string JobCategoryDto { get; set; }  = string.Empty;
        public decimal Price { get; set; } = 0;
        public JobPosterDto Poster { get; set; } = new JobPosterDto();

    }
}
