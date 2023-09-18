using API.Dtos.Character;
using API.Dtos.Weapon;
using API.Models;

namespace API.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeaponAsync(AddWeaponDto newWeapon);
    }
}
