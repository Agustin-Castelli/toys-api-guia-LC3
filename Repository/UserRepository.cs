﻿using AutoMapper;
using Data.DTOs;
using Data.Mappings;
using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository
    {
        private readonly toystoreContext _context;
        private readonly IMapper _mapper;

        public UserRepository(toystoreContext context)
        {
            _context = context;
            _mapper = AutoMapperConfig.Configure();
        }

        public List<UserDTO> GetUsers()
        {
            var users = _context.users.ToList();
            var response = _mapper.Map<List<UserDTO>>(users);
            return response;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _context.users.SingleOrDefault(u => u.user_id == id);
            var response = _mapper.Map<UserDTO>(user);
            return response;
        }

        public UserDTO AddUser(UserViewModel user)
        {
            UserDTO newUser = new UserDTO();

            _context.users.Add(new users()
            {
                name = user.name,
                email = user.email,
                password = user.password,
                role_id = user.role_id,
                state = user.state,
            });

            _context.SaveChanges();

            newUser.name = user.name;
            newUser.email = user.email;
            newUser.password = user.password;
            newUser.role_id = user.role_id;
            newUser.state = user.state;

            return newUser;
        }

        public UserDTO UpdateUser(UserViewModel user)
        {
            users userDB = _context.users.Single(f => f.user_id == user.user_id);
            UserDTO newUser = new UserDTO();


            userDB.name = user.name;
            userDB.email = user.email;
            userDB.password = user.password;
            userDB.role_id = user.role_id;
            userDB.state = user.state;
            
            _context.SaveChanges();

            newUser.name = user.name;
            newUser.email = user.email;
            newUser.password = user.password;
            newUser.role_id = user.role_id;
            newUser.state = user.state;
            
            return newUser;
        }

        public void DeleteUser(int id)
        {
            //_context.users.Remove(_context.users.Single(u => u.user_id == id));
            //For now, we just delete ir logically
            users user = _context.users.Single(u => u.user_id == id);
            if (user.state == true)
            {
                user.state = false;
            }
            _context.SaveChanges();
        }

        public void RecoverUser(int id)
        {
            users user = _context.users.Single(u => u.user_id == id);
            if(user.state == false)
            {
                user.state = true;
            }
            _context.SaveChanges();
        }

    }
}
