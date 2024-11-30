using OnlineEdu.DTO.DTOs.AboutDTOs;

namespace OnlineEdu.DTO.DTOs.FeatureDTOs
{
    public class ResultFeatureDTO
    {
        public int FeatureID { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
    }
}
