namespace ResourceAuthExample.Controllers
{
    public class Item : NewItem
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }
    }
}
