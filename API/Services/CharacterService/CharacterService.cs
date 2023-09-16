using API.Dtos.Character;
using API.Models;
using AutoMapper;

namespace API.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {

            new Character(),
            new Character{ Id = 2,Name = "Mario", Class = RpgClass.Mega}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacterAsync(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<GetCharacterDto>(newCharacter);
            character.Id = characters.Max(x => x.Id) + 1;
            characters.Add(_mapper.Map<Character>(newCharacter));
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharactersAsync(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {

                var character = characters.FirstOrDefault(c => c.Id == id);

                if (character is null) throw new Exception($"Character with Id '{id}'Not Found");

                characters.Remove(character);

                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Massage = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharactersAsync()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
         
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterByIdAsync(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.SingleOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>( character);
            if (serviceResponse == null) throw new Exception("Character not found");

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacterAsync(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try 
            {
                
                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                if (character == null) throw new Exception($"Character with Id '{updatedCharacter.Id}'Not Found");

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strengh = updatedCharacter.Strengh;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

                
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Massage = ex.Message;
            }

            return serviceResponse;
        }
    }
}
