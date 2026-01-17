using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDTO>()
               .ReverseMap();
            cfg.CreateMap<Book, BookDTO>()
              .ReverseMap();
            cfg.CreateMap<User, UserDTO>()
              .ReverseMap();
            cfg.CreateMap<Order, OrderDTO>()
             .ReverseMap();
            cfg.CreateMap<Order, SummaryDTO>()
            .ReverseMap();
        });
       
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }


    }
}
