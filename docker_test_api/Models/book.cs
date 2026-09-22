namespace docker_test_api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTimeOffset CratedDate { get; set; }

    }

}
