namespace Streetwood.Infrastructure.Dto
{
    public class NewOrderDto
    {
        public int Id { get; set; }

        public NewOrderDto(int id)
        {
            Id = id;
        }

        protected NewOrderDto()
        {
        }
    }
}
