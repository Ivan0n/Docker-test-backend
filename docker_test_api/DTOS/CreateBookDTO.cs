namespace docker_test_api.DTOS
{
    public class CreateBookDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTimeOffset CratedDate { get; set; }
    }
}
