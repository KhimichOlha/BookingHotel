﻿using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ConfirmBooking : IBookingCommand
    {
        private readonly IBookingRepository _repository;
        private readonly IBookingState _state;
        public ConfirmBooking(IBookingRepository repository, IBookingState state)
        {
            _repository = repository;
            _state = state;
        }

        public void Execute(Booking booking)
        {

            if (booking != null)
            {
                _state.Confirm(booking);
                _repository.Update(booking);

            }
            else
            {
                throw new NullReferenceException("Обєкт бронювання не пітверджено");
            }
        }
    }
}
