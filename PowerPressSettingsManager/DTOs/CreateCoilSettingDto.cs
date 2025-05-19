namespace PowerPressSettingsManager.DTOs
{
    public class CreateCoilSettingDto
    {
        public int MaterialGrade { get; set; }
        public int FeedLenght { get; set; }
        public bool RunSide { get; set; }
        public bool ProgressionOrTransfer { get; set; }
        public decimal LeftHight { get; set; }
        public decimal RightHight { get; set; }
        public int RecommendedSpeedFeeder { get; set; }
    }
}