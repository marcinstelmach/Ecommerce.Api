namespace Streetwood.API.ViewModels.Slides
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateSlideOrderIndexViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int OrderIndex { get; set; }
    }
}