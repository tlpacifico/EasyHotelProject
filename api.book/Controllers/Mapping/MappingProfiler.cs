using System.Linq;
using AutoMapper;
using Data.Core.Domain;
using book.api.Controllers.Mapping.Resources;
using System;
using api.book.Util;

namespace book.api.Controllers.Mapping
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<Book, BookResource>()
                .ForMember(br => br.Guests, opt => opt
                .MapFrom(s => s.Guests.Select(x => new GuestResource
                {
                    Id = x.Guest.Id,
                    Cpf = x.Guest.Cpf,
                    Nome = x.Guest.Nome,
                    Fone = x.Guest.Fone,
                    DtNascimento = x.Guest.DtNascimento,
                    Email = x.Guest.Email,
                    Endereco = new EnderecoResource
                    {
                        Uf = x.Guest.Uf,
                        Cidade = x.Guest.Cidade,
                        Logradouro = x.Guest.Logradouro,
                        Bairro = x.Guest.Bairro,
                        Numero = x.Guest.Numero,
                        Cep = x.Guest.Cep,
                        Prefixo = x.Guest.Prefixo
                    }
                })));
            CreateMap<SaveBookResource, Book>()
            .ForMember(sbr => sbr.Guests, opt => opt.Ignore())
            .ForMember(sbr => sbr.CheckIn, opt => opt.Ignore())
            .ForMember(sbr => sbr.CheckOut, opt => opt.Ignore())
            .ForMember(sbr => sbr.Id, opt => opt.Ignore())
            .AfterMap((sbr, b) =>
                     {

                         // Remove unselected roomBeds
                         var guets = b.Guests.Where(f => !sbr.Guests.Any(x => x == f.GuestId)).ToList();
                         foreach (var f in guets)
                             b.Guests.Remove(f);

                         // Add new RoomBeds
                         var addedGuets = sbr.Guests.Where(x => !b.Guests.Any(f => f.GuestId == x)).Select(x => new GuestBook { GuestId = x }).ToList();
                         foreach (var f in addedGuets)
                             b.Guests.Add(f);

                         b.CheckIn = DateTime.Now;
                         b.TotalBill = sbr.RoomRate;
                         
                         if (String.IsNullOrEmpty(sbr.CheckOut))
                             b.CheckOut = DateTime.Now.AddDays(1);
                         else
                         {
                             b.CheckOut = ParseString.ParseStringToDateTime(sbr.CheckOut);
                         }


                     });

            CreateMap<Guest, GuestResource>()
                .ForMember(gr => gr.Endereco, opt => opt
                .MapFrom(g => new EnderecoResource
                {
                    Uf = g.Uf,
                    Cidade = g.Cidade,
                    Logradouro = g.Logradouro,
                    Bairro = g.Bairro,
                    Numero = g.Numero,
                    Cep = g.Cep,
                    Prefixo = g.Prefixo
                }));

            CreateMap<GuestResource, Guest>()
                    .ForMember(g => g.Uf, opt => opt.MapFrom(gr => gr.Endereco.Uf))
                    .ForMember(g => g.Cidade, opt => opt.MapFrom(gr => gr.Endereco.Cidade))
                    .ForMember(g => g.Logradouro, opt => opt.MapFrom(gr => gr.Endereco.Logradouro))
                    .ForMember(g => g.Bairro, opt => opt.MapFrom(gr => gr.Endereco.Bairro))
                    .ForMember(g => g.Numero, opt => opt.MapFrom(gr => gr.Endereco.Numero))
                    .ForMember(g => g.Cep, opt => opt.MapFrom(gr => gr.Endereco.Cep))
                    .ForMember(g => g.Prefixo, opt => opt.MapFrom(gr => gr.Endereco.Prefixo));

            CreateMap<Bed, KeyValuePairResource>()
                    .ForMember(r => r.Name, opt => opt.MapFrom(v => v.Description)); ; ;
            CreateMap<RoomState, KeyValuePairResource>()
                    .ForMember(r => r.Name, opt => opt.MapFrom(v => v.State));
            CreateMap<RoomType, KeyValuePairResource>()
                     .ForMember(r => r.Name, opt => opt.MapFrom(v => v.Description)); ;
            CreateMap<SaveRoomResource, Room>()
                    .ForMember(r => r.Id, opt => opt.Ignore())
                    .ForMember(r => r.Beds, opt => opt.Ignore())
                     .AfterMap((rr, r) =>
                     {
                         // Remove unselected roomBeds
                         var roomBeds = r.Beds.Where(f => !rr.Beds.Any(x => x.BedId == f.BedId)).ToList();
                         foreach (var f in roomBeds)
                             r.Beds.Remove(f);

                         // Add new RoomBeds
                         var addedRoomBeds = rr.Beds.Where(x => !r.Beds.Any(f => f.BedId == x.BedId)).Select(x => new RoomBed { BedId = x.BedId, NumberBeds = x.NumberBeds }).ToList();
                         foreach (var f in addedRoomBeds)
                         {
                             f.RoomId = r.Id;
                             r.Beds.Add(f);
                         }

                     });

            CreateMap<Room, RoomResource>()
            .ForMember(rr => rr.RoomType, opt => opt
                                .MapFrom(r => new KeyValuePairResource
                                {
                                    Id = r.RoomType.Id,
                                    Name = r.RoomType.Description
                                }))
            .ForMember(rr => rr.RoomState, opt => opt
                                .MapFrom(r => new KeyValuePairResource
                                {
                                    Id = r.RoomState.Id,
                                    Name = r.RoomState.State
                                }))
            .ForMember(rr => rr.Beds, opt => opt
                        .MapFrom(r => r.Beds
                            .Select(rb => new RoomBedResource
                            {
                                BedId = rb.Bed.Id,
                                Name = rb.Bed.Description,
                                NumberBeds = rb.NumberBeds
                            })))
            .ForMember(rr => rr.CurrentBook, opt => opt.MapFrom(r => new BookResource
            {
                Id = r.CurrentBook.Id,
                CheckIn = r.CurrentBook.CheckIn,
                CheckOut = r.CurrentBook.CheckOut,
                Room = null,
                GuestNumber = r.CurrentBook.GuestNumber,
                RoomRate = r.CurrentBook.RoomRate,
                TotalBill = r.CurrentBook.TotalBill,
                Guests = r.CurrentBook.Guests
                                                  .Select(x => new GuestResource
                                                  {
                                                      Id = x.Guest.Id,
                                                      Cpf = x.Guest.Cpf,
                                                      Nome = x.Guest.Nome,
                                                      Fone = x.Guest.Fone,
                                                      DtNascimento = x.Guest.DtNascimento,
                                                      Email = x.Guest.Email,
                                                      Endereco = null
                                                  }).ToList()

            }));


        }
    }
}