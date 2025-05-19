namespace PowerPressSettingsManager.DTOs
{
    public class CreatePressSettingDto
    {
        public string PartNumber { get; set; } = string.Empty;
        public float ClampingHight { get; set; }
        public float RunningHight { get; set; }
        public int RecommendedRunningSpeed { get; set; }
        public int MagnetBeltSpeed { get; set; }
        public DateTime LastTimeRun { get; set; } = DateTime.Now;

        public CreateCoilSettingDto CoilSetting { get; set; } = new();
    }
}
