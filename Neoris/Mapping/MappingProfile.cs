using AutoMapper;
using Neoris.DTOs;
using System.Collections.Generic;

namespace Neoris.Mapping
{
    public class MappingProfile:  Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteDto, Cliente>();
            CreateMap<Cliente, ClienteDto>();
            CreateMap<CuentasDto, Cuenta>();
            CreateMap<Cuenta, CuentasDto>();

            CreateMap<MovimientoDto, Movimiento>();
            CreateMap<Movimiento, MovimientoDto>();
             
        }
    }
}
