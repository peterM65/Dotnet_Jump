using API.Dtos.Fight;
using API.Models;

namespace API.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttackAsync(WeaponAttackDto request);
        Task<ServiceResponse<AttackResultDto>> SkillAttackAsync(SkillAttackDto request);
        Task<ServiceResponse<FightResultDto>> FightAsync(FightRequestDto request);
        Task<ServiceResponse<List<HighscoreDto>>> GetHighscoreAsync();
    }
}
