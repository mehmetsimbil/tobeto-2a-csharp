
namespace Business.Responses.Car
{
    public class AddCarResponse
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public AddCarResponse(string name,int id, DateTime createdAt)
        {
            Name = name;
            Id = id;
            CreatedAt = createdAt;
        }

       
    }
}
