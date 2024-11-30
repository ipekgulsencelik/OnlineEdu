using OnlineEdu.WebUI.DTOs.AboutDTOs;

namespace OnlineEdu.WebUI.DTOs.FeatureDTOs
{
    public class ResultFeatureDTO
    {
        public int FeatureID { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
    }
}
