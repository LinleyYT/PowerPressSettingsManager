namespace PowerPressSettingsManager.Moduls
{
    public class PressSetting
    {
        public int Id { get; set; }
        public required string PartNumber { get; set; }
        public float ClampingHight { get; set; }
        public float RunningHight { get; set; }
        public int RecommendedRunningSpeed { get; set; }
        public int MagnetBeltSpeed { get; set; }
        public DateTime LastTimeRun { get; set; } = DateTime.Now;

        public CoilSetting CoilSetting { get; set; } = null!;


    }
}
