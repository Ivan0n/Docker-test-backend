namespace docker_test_api.DTOS
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTimeOffset CratedDate { get; set; }
    }
}
