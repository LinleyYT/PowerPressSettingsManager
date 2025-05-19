using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerPressSettingsManager.Data;
using PowerPressSettingsManager.DTOs;
using PowerPressSettingsManager.Moduls;
using PowerPressSettingsManager.Validator;

namespace PowerPressSettingsManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PressSettingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PressSettingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePressSettings([FromBody] CreatePressSettingDto dto)
        {
            try
            {

                var validator = new CreatePressSettingDtoValidator();
                var validationResult = await validator.ValidateAsync(dto);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new { message = "Validation failed.", errors = validationResult.Errors });
                }
                var pressSetting = new PressSetting
                {
                    PartNumber = dto.PartNumber,
                    ClampingHight = dto.ClampingHight,
                    RunningHight = dto.RunningHight,
                    RecommendedRunningSpeed = dto.RecommendedRunningSpeed,
                    MagnetBeltSpeed = dto.MagnetBeltSpeed,
                    LastTimeRun = dto.LastTimeRun,
                    CoilSetting = new CoilSetting
                    {
                        MaterialGrade = dto.CoilSetting.MaterialGrade,
                        FeedLenght = dto.CoilSetting.FeedLenght,
                        RunSide = dto.CoilSetting.RunSide,
                        ProgressionOrTransfer = dto.CoilSetting.ProgressionOrTransfer,
                        LeftHight = dto.CoilSetting.LeftHight,
                        RightHight = dto.CoilSetting.RightHight,
                        RecommendedSpeedFeeder = dto.CoilSetting.RecommendedSpeedFeeder
                    }
                };


                _context.PressSettings.Add(pressSetting);
                await _context.SaveChangesAsync();

                return Ok(new { id = pressSetting.Id });
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while creating the PressSetting.");
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PressSettingDto>>> GetPressSettings()
        {
            var pressSettings = await _context.PressSettings
                .Include(p => p.CoilSetting)
                .ToListAsync();

            var result = pressSettings.Select(p => new PressSettingDto
            {
                Id = p.Id,
                PartNumber = p.PartNumber,
                ClampingHight = p.ClampingHight,
                RunningHight = p.RunningHight,
                RecommendedRunningSpeed = p.RecommendedRunningSpeed,
                MagnetBeltSpeed = p.MagnetBeltSpeed,
                LastTimeRun = p.LastTimeRun,
                CoilSetting = new CoilSettingDto
                {
                    MaterialGrade = p.CoilSetting.MaterialGrade,
                    FeedLenght = p.CoilSetting.FeedLenght,
                    RunSide = p.CoilSetting.RunSide,
                    ProgressionOrTransfer = p.CoilSetting.ProgressionOrTransfer,
                    LeftHight = p.CoilSetting.LeftHight,
                    RightHight = p.CoilSetting.RightHight,
                    RecommendedSpeedFeeder = p.CoilSetting.RecommendedSpeedFeeder
                }
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PressSettingDto>> GetPressSetting(int id)
        {
            var pressSetting = await _context.PressSettings
                .Include(p => p.CoilSetting)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pressSetting == null)
            {
                return NotFound(new { message = $"PressSetting with ID {id} not found." });
            }
            var result = new PressSettingDto
            {
                Id = pressSetting.Id,
                PartNumber = pressSetting.PartNumber,
                ClampingHight = pressSetting.ClampingHight,
                RunningHight = pressSetting.RunningHight,
                RecommendedRunningSpeed = pressSetting.RecommendedRunningSpeed,
                MagnetBeltSpeed = pressSetting.MagnetBeltSpeed,
                LastTimeRun = pressSetting.LastTimeRun,
                CoilSetting = new CoilSettingDto
                {
                    MaterialGrade = pressSetting.CoilSetting.MaterialGrade,
                    FeedLenght = pressSetting.CoilSetting.FeedLenght,
                    RunSide = pressSetting.CoilSetting.RunSide,
                    ProgressionOrTransfer = pressSetting.CoilSetting.ProgressionOrTransfer,
                    LeftHight = pressSetting.CoilSetting.LeftHight,
                    RightHight = pressSetting.CoilSetting.RightHight,
                    RecommendedSpeedFeeder = pressSetting.CoilSetting.RecommendedSpeedFeeder
                }
            };
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePressSetting(int id, [FromBody] PressSettingDto dto)
        {
            var pressSetting = await _context.PressSettings
                .Include(p => p.CoilSetting)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pressSetting == null)
            {
                return NotFound(new { message = $"PressSetting with ID {id} not found." });
            }
            pressSetting.PartNumber = dto.PartNumber;
            pressSetting.ClampingHight = dto.ClampingHight;
            pressSetting.RunningHight = dto.RunningHight;
            pressSetting.RecommendedRunningSpeed = dto.RecommendedRunningSpeed;
            pressSetting.MagnetBeltSpeed = dto.MagnetBeltSpeed;
            pressSetting.LastTimeRun = dto.LastTimeRun;
            pressSetting.CoilSetting.MaterialGrade = dto.CoilSetting.MaterialGrade;
            pressSetting.CoilSetting.FeedLenght = dto.CoilSetting.FeedLenght;
            pressSetting.CoilSetting.RunSide = dto.CoilSetting.RunSide;
            pressSetting.CoilSetting.ProgressionOrTransfer = dto.CoilSetting.ProgressionOrTransfer;
            pressSetting.CoilSetting.LeftHight = dto.CoilSetting.LeftHight;
            pressSetting.CoilSetting.RightHight = dto.CoilSetting.RightHight;
            pressSetting.CoilSetting.RecommendedSpeedFeeder = dto.CoilSetting.RecommendedSpeedFeeder;
            await _context.SaveChangesAsync();
            return Ok(new { message = $"PressSetting with ID {id} updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePressSetting(int id)
        {
            var pressSetting = await _context.PressSettings
                .Include(p => p.CoilSetting)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pressSetting == null)
            {
                return NotFound(new { message = $"PressSetting with ID {id} not found." });
            }
            _context.PressSettings.Remove(pressSetting);
            await _context.SaveChangesAsync();
            return Ok(new { message = $"PressSetting with ID {id} deleted successfully." });
        }
    }
}
