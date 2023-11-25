﻿using AutoMapper;
using Data.DTOs;
using Data.Mappings;
using Data.Models;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ToyRepository
    {
        private readonly toystoreContext _context;
        private readonly IMapper _mapper;

        public ToyRepository(toystoreContext context)
        {
            _context = context;
            _mapper = AutoMapperConfig.Configure();
        }

        public List<ToyDTO> GetToys()
        {
            var toys = _context.toys.ToList();
            var response = _mapper.Map<List<ToyDTO>>(toys);
            return response;
        }
        public ToyDTO GetToyById(int id)
        {
            var toy =_context.toys.SingleOrDefault(t => t.code == id);
            var response = _mapper.Map<ToyDTO>(toy);
            return response;
        }
        public ToyDTO GetToyPricesById(int id)
        {
            var toyWithPrices = _context.toys
                .Where(t => t.code == id)
                .Include(t => t.price_history)
                .FirstOrDefault();

                var toyDTO = _mapper.Map<ToyDTO>(toyWithPrices);

                // Convert the HashSet<price_history> to List<price_history>
                var priceHistoryList = toyWithPrices.price_history.ToList();

                // Map the price history to a list of PriceDTO
                toyDTO.PriceHistory = _mapper.Map<List<PriceDTO>>(priceHistoryList);

                return toyDTO;
        }
        public ToyDTO AddToy(ToyViewModel toy)
        {
            ToyDTO newToy = new ToyDTO();

            _context.toys.Add(new toys()
            {
                code = toy.code,
                name = toy.name,
                category_id = toy.category_id,
                description = toy.description,
                stock = toy.stock,
                stock_threshold = toy.stock_threshold,
                state = toy.state,
                price = toy.price,
            });

            _context.SaveChanges();

            newToy.code = toy.code;
            newToy.name = toy.name;
            newToy.category_id = toy.category_id;
            newToy.description = toy.description;
            newToy.state = toy.state;
            newToy.stock = toy.stock;
            newToy.stock_threshold = toy.stock_threshold;
            newToy.price = toy.price;

            return newToy;
        }

        public ToyDTO ChangePrice(int id, int newPrice)
        {
            // Retrieve the toy with the specified ID
            var toy = _context.toys.SingleOrDefault(t => t.code == id);

            if (toy == null)
            {
                // Handle the case where the toy with the specified ID is not found
                return null;
            }

            // Save the current price to the price_history table
            var priceHistory = new price_history
            {
                toy_code = toy.code,
                price = toy.price,
                change_date = DateTime.Now // You can adjust the date as needed
            };

            _context.price_history.Add(priceHistory);

            // Update the price of the toy
            toy.price = newPrice;

            // Save changes to the database
            _context.SaveChanges();

            // Map the updated toy to ToyDTO
            var response = _mapper.Map<ToyDTO>(toy);

            return response;
        }

        public void DeleteToy(int id)
        {
            _context.toys.Remove(_context.toys.Single(t => t.code == id));
            _context.SaveChanges();
        }
        public void SoftDeleteToy(int id)
        {
            toys toy = _context.toys.Single(t => t.code == id);
            if (toy.state == true)
            {
                toy.state = false;
            }
            _context.SaveChanges();
        }

        public void RecoverToy(int id)
        {
            toys toy = _context.toys.Single(t => t.code == id);
            if (toy.state == false)
            {
                toy.state = true;
            }
            _context.SaveChanges();
        }
    }
}