using DataAccess;
using Negocio.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class Servicio
    {
        private Repository userRepo;

        public Servicio()
        {
            userRepo = new Repository();
        }

        public void Agregar(UserDto userDto)
        {
            var user = new User()
            {
                UserName = userDto.UserName,
                Password = userDto.Password
            };

            userRepo.Add(user);
            userRepo.SaveChanges();
        }

        public void Eliminar(String name)
        {
            var user = userRepo.ChekByName(name);
            userRepo.Remove(user);
            userRepo.SaveChanges();
        }
        
        public void Modificar(UserDto user)
        {
            var newUser = userRepo.ChekByName(user.UserName);
            newUser.UserName = user.UserName;
            newUser.Password = user.Password;

            userRepo.Update(newUser);
            userRepo.SaveChanges();
        }

        public List<string> Listar()
        {
            var lista = new List<string>();
            return userRepo.Read().ToList();
            
        }
    
    }
}
