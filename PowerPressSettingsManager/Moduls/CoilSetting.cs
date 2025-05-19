namespace PowerPressSettingsManager.Moduls
{
    public class CoilSetting
    {
        public int Id { get; set; }
        public int MaterialGrade { get; set; }
        public int FeedLenght { get; set; }
        public bool RunSide {  get; set; }
        public bool ProgressionOrTransfer { get; set; }
        public decimal LeftHight { get; set; }
        public decimal RightHight { get; set; }
        public int RecommendedSpeedFeeder { get; set; }
        public int PressSettingId { get; set; }
        public PressSetting PressSetting { get; set; } = null!;
    }
}
