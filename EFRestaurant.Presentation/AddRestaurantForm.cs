﻿using System;
using System.Windows.Forms;
using EFRestaurant.Data.Models.Entities;
using EFRestaurant.Domain.Repositories;

namespace EFRestaurant.Presentation
{
    public partial class AddRestaurantForm : Form
    {
        public AddRestaurantForm()
        {
            InitializeComponent();
            _restaurantRepository = new RestaurantRepository();
            KitchenModelComboBox.SelectedIndex = 0;
        }
        private readonly RestaurantRepository _restaurantRepository;

        private void OkButtonNewRestaurant_Click(object sender, EventArgs e)
        {          
            if (string.IsNullOrEmpty(NewRestaurantTextBox.Text))
                MessageBox.Show("The restaurant must have a name!");
            else
            {
                var restaurantToAdd = new Restaurant()
                {
                    Name = NewRestaurantTextBox.Text,
                    KitchenModel = _restaurantRepository.GetKitchenModel(KitchenModelComboBox.SelectedIndex + 1)
                };
                _restaurantRepository.AddRestaurant(restaurantToAdd);
                Close();
            }

        }
    }
}
