using API.Dtos.Character;
using API.Models;

namespace API.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharactersAsync();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterByIdAsync(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacterAsync(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacterAsync(UpdateCharacterDto updatedCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharactersAsync(int id);
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkillAsync(AddCharacterSkillDto newCharacterSkill);
    }
}
