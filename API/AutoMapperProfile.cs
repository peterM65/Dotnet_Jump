﻿using API.Dtos.Character;
using API.Dtos.Fight;
using API.Dtos.Skill;
using API.Dtos.Weapon;
using API.Models;
using AutoMapper;

namespace API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>().ReverseMap();
            CreateMap<AddCharacterDto,Character>().ReverseMap();
            CreateMap<Weapon,GetWeaponDto>().ReverseMap();
            CreateMap<Skill, GetSkillDto>().ReverseMap();
            CreateMap<Character, HighscoreDto>();
        }
    }
}
