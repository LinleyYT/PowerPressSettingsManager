namespace PowerPressSettingsManager.DTOs
{
    public class PressSettingDto
    {
        public int Id { get; set; }
        public string PartNumber { get; set; } = string.Empty;
        public float ClampingHight { get; set; }
        public float RunningHight { get; set; }
        public int RecommendedRunningSpeed { get; set; }
        public int MagnetBeltSpeed { get; set; }
        public DateTime LastTimeRun { get; set; }

        public CoilSettingDto CoilSetting { get; set; } = new();
    }
}
